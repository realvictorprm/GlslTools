﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Projection;
using ShaderTools.CodeAnalysis.Editor.Shared.Utilities;
using ShaderTools.CodeAnalysis.Shared.Extensions;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Editor.Implementation.IntelliSense.QuickInfo
{
    internal abstract partial class AbstractQuickInfoProvider : IQuickInfoProvider
    {
        private readonly IProjectionBufferFactoryService _projectionBufferFactoryService;
        private readonly IEditorOptionsFactoryService _editorOptionsFactoryService;
        private readonly ITextEditorFactoryService _textEditorFactoryService;
        private readonly IGlyphService _glyphService;
        private readonly ClassificationTypeMap _typeMap;
        private readonly ITaggedTextMappingService _taggedTextMappingService;

        protected AbstractQuickInfoProvider(
            IProjectionBufferFactoryService projectionBufferFactoryService,
            IEditorOptionsFactoryService editorOptionsFactoryService,
            ITextEditorFactoryService textEditorFactoryService,
            IGlyphService glyphService,
            ClassificationTypeMap typeMap,
            ITaggedTextMappingService taggedTextMappingService)
        {
            _projectionBufferFactoryService = projectionBufferFactoryService;
            _editorOptionsFactoryService = editorOptionsFactoryService;
            _textEditorFactoryService = textEditorFactoryService;
            _glyphService = glyphService;
            _typeMap = typeMap;
            _taggedTextMappingService = taggedTextMappingService;
        }

        public async Task<QuickInfoItem> GetItemAsync(
            Document document,
            int position,
            CancellationToken cancellationToken)
        {
            var tree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);
            var sourceLocation = tree.MapRootFilePosition(position);
            var token = await tree.GetTouchingTokenAsync(sourceLocation, cancellationToken, findInsideTrivia: true).ConfigureAwait(false);

            if (token == null)
            {
                return null;
            }

            var state = await GetQuickInfoItemAsync(document, tree, token, sourceLocation, cancellationToken).ConfigureAwait(false);
            if (state != null)
            {
                return state;
            }

            if (ShouldCheckPreviousToken(token))
            {
                var previousToken = token.GetPreviousToken();

                if ((state = await GetQuickInfoItemAsync(document, tree, previousToken, sourceLocation, cancellationToken).ConfigureAwait(false)) != null)
                {
                    return state;
                }
            }

            return null;
        }

        protected virtual bool ShouldCheckPreviousToken(ISyntaxToken token)
        {
            return true;
        }

        private async Task<QuickInfoItem> GetQuickInfoItemAsync(
            Document document,
            SyntaxTreeBase syntaxTree,
            ISyntaxToken token,
            SourceLocation sourceLocation,
            CancellationToken cancellationToken)
        {
            if (token != default(ISyntaxToken) &&
                token.SourceRange.Contains(sourceLocation))
            {
                var deferredContent = await BuildContentAsync(document, token, cancellationToken).ConfigureAwait(false);
                if (deferredContent != null)
                {
                    var rootSpan = syntaxTree.GetSourceFileSpan(token.SourceRange).Span;
                    return new QuickInfoItem(rootSpan, deferredContent);
                }
            }

            return null;
        }

        protected abstract Task<IDeferredQuickInfoContent> BuildContentAsync(Document document, ISyntaxToken token, CancellationToken cancellationToken);

        protected IDeferredQuickInfoContent CreateQuickInfoDisplayDeferredContent(
            ISymbol symbol,
            bool showWarningGlyph,
            bool showSymbolGlyph,
            IList<TaggedText> mainDescription,
            IDeferredQuickInfoContent documentation,
            IList<TaggedText> typeParameterMap,
            IList<TaggedText> anonymousTypes,
            IList<TaggedText> usageText,
            IList<TaggedText> exceptionText)
        {
            return new QuickInfoDisplayDeferredContent(
                symbolGlyph: showSymbolGlyph ? CreateGlyphDeferredContent(symbol) : null,
                warningGlyph: showWarningGlyph ? CreateWarningGlyph() : null,
                mainDescription: CreateClassifiableDeferredContent(mainDescription),
                documentation: documentation,
                typeParameterMap: CreateClassifiableDeferredContent(typeParameterMap),
                anonymousTypes: CreateClassifiableDeferredContent(anonymousTypes),
                usageText: CreateClassifiableDeferredContent(usageText),
                exceptionText: CreateClassifiableDeferredContent(exceptionText));
        }

        private IDeferredQuickInfoContent CreateWarningGlyph()
        {
            return new SymbolGlyphDeferredContent(Glyph.CompletionWarning, _glyphService);
        }

        protected IDeferredQuickInfoContent CreateQuickInfoDisplayDeferredContent(
            Glyph glyph,
            IList<TaggedText> mainDescription,
            IDeferredQuickInfoContent documentation,
            IList<TaggedText> typeParameterMap,
            IList<TaggedText> anonymousTypes,
            IList<TaggedText> usageText,
            IList<TaggedText> exceptionText)
        {
            return new QuickInfoDisplayDeferredContent(
                symbolGlyph: new SymbolGlyphDeferredContent(glyph, _glyphService),
                warningGlyph: null,
                mainDescription: CreateClassifiableDeferredContent(mainDescription),
                documentation: documentation,
                typeParameterMap: CreateClassifiableDeferredContent(typeParameterMap),
                anonymousTypes: CreateClassifiableDeferredContent(anonymousTypes),
                usageText: CreateClassifiableDeferredContent(usageText),
                exceptionText: CreateClassifiableDeferredContent(exceptionText));
        }

        protected IDeferredQuickInfoContent CreateGlyphDeferredContent(ISymbol symbol)
        {
            return new SymbolGlyphDeferredContent(symbol.GetGlyph(), _glyphService);
        }

        protected IDeferredQuickInfoContent CreateClassifiableDeferredContent(
            IList<TaggedText> content)
        {
            return new ClassifiableDeferredContent(content, _typeMap, _taggedTextMappingService);
        }

        protected IDeferredQuickInfoContent CreateDocumentationCommentDeferredContent(
            string documentationComment)
        {
            return new DocumentationCommentDeferredContent(documentationComment, _typeMap);
        }

        protected IDeferredQuickInfoContent CreateElisionBufferDeferredContent(SnapshotSpan span)
        {
            return new ElisionBufferDeferredContent(
                span, _projectionBufferFactoryService, _editorOptionsFactoryService, _textEditorFactoryService);
        }
    }
}
