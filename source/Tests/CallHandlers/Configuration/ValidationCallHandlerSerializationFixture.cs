// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.TestSupport;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.PolicyInjection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationCallHandler = Microsoft.Practices.EnterpriseLibrary.Validation.PolicyInjection.ValidationCallHandler;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests.Configuration
{
    [TestClass]
    public class ValidationCallHandlerSerializationFixture : CallHandlerDataFixtureBase
    {
        [TestMethod]
        public void CanDeserializeValidationCallHandlerData()
        {
            ValidationCallHandlerData data = new ValidationCallHandlerData("Logging Handler");
            data.RuleSet = "MyRuleSet";
            data.SpecificationSource = SpecificationSource.Configuration;
            data.Order = 7;

            ValidationCallHandlerData deserialized =
                (ValidationCallHandlerData)SerializeAndDeserializeHandler(data);

            Assert.AreEqual(data.RuleSet, deserialized.RuleSet);
            Assert.AreEqual(data.SpecificationSource, deserialized.SpecificationSource);
            Assert.AreEqual(typeof(ValidationCallHandler), deserialized.Type);
            Assert.AreEqual(data.Order, deserialized.Order);
        }

        private static MethodImplementationInfo GetMethodImpl(MethodBase method)
        {
            return new MethodImplementationInfo(null, ((MethodInfo)method));
        }
    }
}
