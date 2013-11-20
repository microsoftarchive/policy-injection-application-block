// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Tests.Configuration
{
    [TestClass]
    public class GivenAnExceptionCallHandlerData
    {
        private CallHandlerData callHandlerData;

        [TestInitialize]
        public void Setup()
        {
            callHandlerData =
                new ExceptionCallHandlerData("exception")
                {
                    Order = 400,
                    ExceptionPolicyName = "policy"
                };
        }

        [TestMethod]
        public void WhenConfiguredContainer_ThenCanResolveCallHandler()
        {
            using (var container = new UnityContainer())
            {
                // TODO review after updating call handler
                var policy = new ExceptionPolicyDefinition("policy", new ExceptionPolicyEntry[0]);
                container.RegisterInstance("policy", policy);

                this.callHandlerData.ConfigureContainer(container, "-suffix");

                var handler = (ExceptionCallHandler)container.Resolve<ICallHandler>("exception-suffix");

                Assert.AreEqual(400, handler.Order);
                Assert.AreSame("policy", handler.ExceptionPolicyName);

                Assert.AreNotSame(handler, container.Resolve<ICallHandler>("exception-suffix"));
            }
        }
    }
}
