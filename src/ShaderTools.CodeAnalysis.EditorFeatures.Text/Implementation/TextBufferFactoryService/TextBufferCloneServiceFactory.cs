﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.CodeAnalysis.Host;
using ShaderTools.CodeAnalysis.Host.Mef;

namespace ShaderTools.CodeAnalysis.Text.Implementation.TextBufferFactoryService
{
    [ExportWorkspaceServiceFactory(typeof(ITextBufferCloneService)), Shared]
    internal class TextBufferCloneServiceFactory : IWorkspaceServiceFactory
    {
        private readonly ITextBufferCloneService _singleton;

        [ImportingConstructor]
        public TextBufferCloneServiceFactory(
            ITextBufferFactoryService textBufferFactoryService,
            IContentTypeRegistryService contentTypeRegistry)
        {
            _singleton = new TextBufferCloneService((ITextBufferFactoryService2) textBufferFactoryService, contentTypeRegistry.UnknownContentType);
        }

        public IWorkspaceService CreateService(HostWorkspaceServices workspaceServices)
        {
            return _singleton;
        }

        private class TextBufferCloneService : ITextBufferCloneService
        {
            private readonly ITextBufferFactoryService2 _textBufferFactoryService;
            private readonly IContentType _unknownContentType;

            public TextBufferCloneService(ITextBufferFactoryService2 textBufferFactoryService, IContentType unknownContentType)
            {
                _textBufferFactoryService = textBufferFactoryService;
                _unknownContentType = unknownContentType;
            }

            public ITextBuffer Clone(SnapshotSpan span)
            {
                return _textBufferFactoryService.CreateTextBuffer(span, _unknownContentType);
            }
        }
    }
}
