﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace ShaderTools.Testing.TestResources
{
    public abstract class TestSuiteDataAttribute : DataAttribute
    {
        protected abstract string DirectoryName { get; }

        protected abstract IEnumerable<string> FileExtensions { get; }

        public sealed override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            var fileExtensions = FileExtensions.ToList();
            return Directory.GetFiles(DirectoryName, "*.*", SearchOption.AllDirectories)
                .Where(x =>
                {
                    var ext = Path.GetExtension(x).ToLower();
                    return fileExtensions.Contains(ext);
                })
                .Select(x => new object[] { x });
        }
    }
}
