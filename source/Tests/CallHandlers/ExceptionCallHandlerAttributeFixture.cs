// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests
{
    [TestClass]
    public class ExceptionCallHandlerAttributeFixture
    {
        [TestMethod]
        public void ShouldCreateHandlerWithCorrectPolicy()
        {
            string policyName = "Swallow Exceptions";
            ExceptionCallHandlerAttribute attribute = new ExceptionCallHandlerAttribute(policyName);
            attribute.Order = 400;

            IUnityContainer container = new UnityContainer();
            var policy = new ExceptionPolicyDefinition(policyName, new ExceptionPolicyEntry[0]);
            container.RegisterInstance(policyName, policy);

            ExceptionCallHandler handler = (ExceptionCallHandler)attribute.CreateHandler(container);
            Assert.AreEqual(policyName, handler.ExceptionPolicyName);
            Assert.AreEqual(400, handler.Order);
        }
    }
}
