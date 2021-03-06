﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using ShaderTools.CodeAnalysis.Editor.Commands;
using ShaderTools.CodeAnalysis.Editor.Shared.Extensions;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Shared.TestHooks;
using ShaderTools.CodeAnalysis.Text;
using ShaderTools.Utilities.ErrorReporting;

namespace ShaderTools.CodeAnalysis.Editor.Implementation.IntelliSense.QuickInfo
{
    internal partial class Controller :
        AbstractController<Session<Controller, Model, IQuickInfoPresenterSession>, Model, IQuickInfoPresenterSession, IQuickInfoSession>,
        ICommandHandler<InvokeQuickInfoCommandArgs>
    {
        private static readonly object s_quickInfoPropertyKey = new object();

        private readonly IList<Lazy<IQuickInfoProvider, OrderableLanguageMetadata>> _allProviders;
        private IList<IQuickInfoProvider> _providers;

        public Controller(
            ITextView textView,
            ITextBuffer subjectBuffer,
            IIntelliSensePresenter<IQuickInfoPresenterSession, IQuickInfoSession> presenter,
            IAsynchronousOperationListener asyncListener,
            IDocumentProvider documentProvider,
            IList<Lazy<IQuickInfoProvider, OrderableLanguageMetadata>> allProviders)
            : base(textView, subjectBuffer, presenter, asyncListener, documentProvider, "QuickInfo")
        {
            _allProviders = allProviders;
        }

        // For testing purposes
        internal Controller(
            ITextView textView,
            ITextBuffer subjectBuffer,
            IIntelliSensePresenter<IQuickInfoPresenterSession, IQuickInfoSession> presenter,
            IAsynchronousOperationListener asyncListener,
            IDocumentProvider documentProvider,
            IList<IQuickInfoProvider> providers)
            : base(textView, subjectBuffer, presenter, asyncListener, documentProvider, "QuickInfo")
        {
            _providers = providers;
        }

        internal static Controller GetInstance(
            CommandArgs args,
            IIntelliSensePresenter<IQuickInfoPresenterSession, IQuickInfoSession> presenter,
            IAsynchronousOperationListener asyncListener,
            IList<Lazy<IQuickInfoProvider, OrderableLanguageMetadata>> allProviders)
        {
            var textView = args.TextView;
            var subjectBuffer = args.SubjectBuffer;
            return textView.GetOrCreatePerSubjectBufferProperty(subjectBuffer, s_quickInfoPropertyKey,
                (v, b) => new Controller(v, b,
                    presenter,
                    asyncListener,
                    new DocumentProvider(),
                    allProviders));
        }

        internal override void OnModelUpdated(Model modelOpt)
        {
            AssertIsForeground();
            if (modelOpt == null || modelOpt.TextVersion != this.SubjectBuffer.CurrentSnapshot.Version)
            {
                this.StopModelComputation();
            }
            else
            {
                // We want the span to actually only go up to the caret.  So get the expected span
                // and then update its end point accordingly.
                ITrackingSpan trackingSpan = null;
                QuickInfoItem item = null;

                // Whether or not we have an item to show, we need to start the session.
                // If the user Edit.QuickInfo's on a squiggle, they want to see the 
                // error text even if there's no symbol quickinfo.
                if (modelOpt.Item != null)
                {
                    item = modelOpt.Item;
                    var triggerSpan = modelOpt.GetCurrentSpanInSnapshot(item.TextSpan, this.SubjectBuffer.CurrentSnapshot);
                    trackingSpan = triggerSpan.CreateTrackingSpan(SpanTrackingMode.EdgeInclusive);
                }
                else
                {
                    var caret = this.TextView.GetCaretPoint(this.SubjectBuffer);
                    if (caret != null)
                        trackingSpan = caret.Value.Snapshot.CreateTrackingSpan(caret.Value.Position, 0, SpanTrackingMode.EdgeInclusive, TrackingFidelityMode.Forward);
                }
                if (trackingSpan != null)
                    sessionOpt.PresenterSession.PresentItem(trackingSpan, item, modelOpt.TrackMouse);
            }
        }

        public void StartSession(
            int position,
            bool trackMouse,
            IQuickInfoSession augmentSession = null)
        {
            AssertIsForeground();

            var providers = GetProviders();
            if (providers == null)
            {
                return;
            }

            var snapshot = this.SubjectBuffer.CurrentSnapshot;
            this.sessionOpt = new Session<Controller, Model, IQuickInfoPresenterSession>(this, new ModelComputation<Model>(this, TaskScheduler.Default),
                this.Presenter.CreateSession(this.TextView, this.SubjectBuffer, augmentSession));

            this.sessionOpt.Computation.ChainTaskAndNotifyControllerWhenFinished(
                (model, cancellationToken) => ComputeModelInBackgroundAsync(position, snapshot, providers, trackMouse, cancellationToken));
        }

        public IList<IQuickInfoProvider> GetProviders()
        {
            this.AssertIsForeground();

            if (_providers == null)
            {
                var snapshot = this.SubjectBuffer.CurrentSnapshot;
                var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
                if (document != null)
                {
                    _providers = document.LanguageServices.WorkspaceServices.SelectMatchingExtensionValues(_allProviders, this.SubjectBuffer.ContentType);
                }
            }

            return _providers;
        }

        private async Task<Model> ComputeModelInBackgroundAsync(
               int position,
               ITextSnapshot snapshot,
               IList<IQuickInfoProvider> providers,
               bool trackMouse,
               CancellationToken cancellationToken)
        {
            try
            {
                AssertIsBackground();

                //using (Logger.LogBlock(FunctionId.QuickInfo_ModelComputation_ComputeModelInBackground, cancellationToken))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var document = await DocumentProvider.GetDocumentAsync(snapshot, cancellationToken).ConfigureAwait(false);
                    if (document == null)
                    {
                        return null;
                    }

                    foreach (var provider in providers)
                    {
                        // TODO(cyrusn): We're calling into extensions, we need to make ourselves resilient
                        // to the extension crashing.
                        var item = await provider.GetItemAsync(document, position, cancellationToken).ConfigureAwait(false);
                        if (item != null)
                        {
                            return new Model(snapshot.Version, item, provider, trackMouse);
                        }
                    }

                    return new Model(snapshot.Version, null, null, trackMouse);
                }
            }
            catch (Exception e) when (FatalError.ReportUnlessCanceled(e))
            {
                throw ExceptionUtilities.Unreachable;
            }
        }
    }
}
