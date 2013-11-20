// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Installers;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.Tests
{
    [RunInstaller(true)]
    public class PerfCounterForCallHandlerTestsInstaller : System.Configuration.Install.Installer
    {
        private readonly PerformanceCountersInstaller countersInstaller;

        public PerfCounterForCallHandlerTestsInstaller()
        {
            countersInstaller = new PerformanceCountersInstaller(PerformanceCounterCallHandlerFixture.TestCategoryName);
            Installers.Add(countersInstaller);
        }
    }
}
