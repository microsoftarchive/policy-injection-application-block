// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Specialized;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.TestSupport.ObjectsUnderTest
{
    /// <summary>
    /// A simple matching rule class that always matches. Useful when you want
    /// a policy to apply across the board.
    /// </summary>
    [ConfigurationElementType(typeof(CustomMatchingRuleData))]
    public class AlwaysMatchingRule : IMatchingRule
    {
        public readonly NameValueCollection configuration;

        public AlwaysMatchingRule()
        {
        }

        public AlwaysMatchingRule(NameValueCollection configuration)
        {
            this.configuration = configuration;
        }

        public bool Matches(MethodBase member)
        {
            return true;
        }
    }
}
