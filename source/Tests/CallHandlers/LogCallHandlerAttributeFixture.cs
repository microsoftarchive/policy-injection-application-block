// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests
{
    [TestClass]
    public class LogCallHandlerAttributeFixture
    {
        [TestCleanup]
        public void TestCleanup()
        {
            Logger.Reset();
        }

        [TestMethod]
        public void ShouldCombineWithPoliciesDefinedInConfiguration()
        {
            using (var configSource = new FileConfigurationSource("CombinesWithConfig.config", false))
            {
                Logger.SetLogWriter(new LogWriterFactory(configSource.GetSection).Create(), false);

                using (var eventLog = new EventLogTracker("Application"))
                {
                    using (var injector = new PolicyInjector(configSource))
                    {
                        var typeWhichUndergoesLoggingOnMethodCall =
                            injector.Create<TypeWhichUndergoesAttributeBasedLogging>();

                        typeWhichUndergoesLoggingOnMethodCall.TestMethod();

                        typeWhichUndergoesLoggingOnMethodCall.MyProperty = "hello";
                    }

                    Assert.AreEqual(2,
                                    eventLog.NewEntries().Select(le => le.Message.Contains("This is before the call")).
                                        Count());
                }
            }
        }
    }

    [LogCallHandler(LogBeforeCall = true, LogAfterCall = false, BeforeMessage = "This is before the call")]
    public class TypeWhichUndergoesAttributeBasedLogging : MarshalByRefObject
    {
        string[] MyCategories = { "Default Category" };

        string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public void TestMethod() { }
    }
}
