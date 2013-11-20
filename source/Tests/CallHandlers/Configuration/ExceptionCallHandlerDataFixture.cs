// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests.Configuration
{
    [TestClass]
    public class ExceptionCallHandlerDataFixture : CallHandlerDataFixtureBase
    {
        [TestMethod]
        public void CanSerializeExceptionCallHandler()
        {
            ExceptionCallHandlerData handlerData =
                new ExceptionCallHandlerData("CallHandler", "Swallow Exceptions");

            ExceptionCallHandlerData deserializedHandler =
                SerializeAndDeserializeHandler(handlerData) as ExceptionCallHandlerData;

            Assert.IsNotNull(deserializedHandler);
            Assert.AreEqual(handlerData.Name, deserializedHandler.Name);
            Assert.AreEqual(handlerData.ExceptionPolicyName, deserializedHandler.ExceptionPolicyName);
        }
    }
}