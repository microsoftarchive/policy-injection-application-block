// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using Microsoft.Practices.Unity;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration
{
    /// <summary>
    /// A configuration element base class that stores configuration information about a matching rule.
    /// </summary>
    public class MatchingRuleData : NameTypeConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchingRuleData"/> class.
        /// </summary>
        public MatchingRuleData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchingRuleData"/> class.
        /// </summary>
        /// <param name="matchingRuleName">The name of the rule in config.</param>
        /// <param name="matchingRuleType">The underlying type of matching rule this object configures.</param>
        public MatchingRuleData(string matchingRuleName, Type matchingRuleType)
            : base(matchingRuleName, matchingRuleType)
        {
        }

        /// <summary>
        /// Configures an <see cref="IUnityContainer"/> to resolve the represented matching rule.
        /// </summary>
        /// <param name="container">The container to configure.</param>
        /// <param name="nameSuffix">The name suffix to use for the matching rule registration name.</param>
        /// <returns>The actual rule registration name.</returns>
        public string ConfigureContainer(IUnityContainer container, string nameSuffix)
        {
            var registrationName = this.Name + nameSuffix;

            this.DoConfigureContainer(container, registrationName);

            return registrationName;
        }

        /// <summary>
        /// Configures an <see cref="IUnityContainer"/> to resolve the represented matching rule by using the specified name.
        /// </summary>
        /// <param name="container">The container to configure.</param>
        /// <param name="registrationName">The name of the registration.</param>
        protected virtual void DoConfigureContainer(IUnityContainer container, string registrationName)
        {
            throw new NotImplementedException(Resources.ExceptionShouldBeImplementedBySubclass);
        }
    }
}
