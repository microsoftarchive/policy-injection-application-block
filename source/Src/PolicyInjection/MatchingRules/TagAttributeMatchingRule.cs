// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Properties;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.MatchingRules
{
    /// <summary>
    /// Placeholder for <see cref="Microsoft.Practices.Unity.InterceptionExtension.TagAttributeMatchingRule"/>.
    /// </summary>
    [ConfigurationElementType(typeof(TagAttributeMatchingRuleData))]
    public class TagAttributeMatchingRule : IMatchingRule
    {
        /// <summary>
        /// Tests to see if this rule applies to the given member.
        /// </summary>
        /// <remarks>
        /// This type is available to support the configuration subsystem. Use 
        /// <see cref="Microsoft.Practices.Unity.InterceptionExtension.TagAttributeMatchingRule"/> instead.
        /// </remarks>
        public bool Matches(System.Reflection.MethodBase member)
        {
            throw new System.InvalidOperationException(Resources.PlaceholderRule);
        }
    }
}
