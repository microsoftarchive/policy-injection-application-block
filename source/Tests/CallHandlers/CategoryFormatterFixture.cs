// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Logging.Tests.PolicyInjection
{
    [TestClass]
    public class CategoryFormatterFixture
    {
        [TestMethod]
        public void ShouldNotReplaceWithoutReplacement()
        {
            string template = "No replacements here";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            Assert.AreEqual(template, formatter.FormatCategory(template));
        }

        [TestMethod]
        public void ShouldReplaceMethodName()
        {
            string template = "Method {method}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            Assert.AreEqual("Method TargetMethod",
                            formatter.FormatCategory(template));
        }

        [TestMethod]
        public void ShouldReplaceTypeName()
        {
            string template = "Type {type}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            Assert.AreEqual("Type CategoryFormatterFixture",
                            formatter.FormatCategory(template));
        }

        [TestMethod]
        public void ShouldReplaceNamespace()
        {
            string template = "Namespace {namespace}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            string formatted = formatter.FormatCategory(template);
            Assert.AreEqual("Namespace Microsoft.Practices.EnterpriseLibrary.Logging.Tests.PolicyInjection",
                            formatted);
        }

        [TestMethod]
        public void ShouldReplaceAssembly()
        {
            string template = "Assembly {assembly}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            string formatted = formatter.FormatCategory(template);

            Assert.IsTrue(formatted.StartsWith("Assembly Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests"));
        }

        [TestMethod]
        public void ShouldProperlyEscapeOpenBraces()
        {
            string template = @"Not a \{namespace}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            string formatted = formatter.FormatCategory(template);
            Assert.AreEqual("Not a {namespace}", formatted);
        }

        [TestMethod]
        public void ShouldPropertyEscapeBackslashes()
        {
            string template = @"Here's a method: \\{method}";
            CategoryFormatter formatter = new CategoryFormatter(GetTargetMethod());
            string formatted = formatter.FormatCategory(template);

            Assert.AreEqual(@"Here's a method: \TargetMethod", formatted);
        }

        MethodBase GetTargetMethod()
        {
            return GetType().GetMethod("TargetMethod");
        }

        public string TargetMethod(int x)
        {
            return x.ToString();
        }
    }
}
