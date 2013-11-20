// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Tests.Configuration
{
    [TestClass]
    public class CustomAttributeMatchingRuleDataFixture : MatchingRuleDataFixtureBase
    {
        [TestMethod]
        public void CanSerializeTypeMatchingRule()
        {
            CustomAttributeMatchingRuleData customAttributeMatchingRule = new CustomAttributeMatchingRuleData("MatchesMyAttribure", "Namespace.MyAttribute, Assembly", true);

            CustomAttributeMatchingRuleData deserializedRule = SerializeAndDeserializeMatchingRule(customAttributeMatchingRule) as CustomAttributeMatchingRuleData;

            Assert.IsNotNull(deserializedRule);
            Assert.AreEqual(customAttributeMatchingRule.Name, deserializedRule.Name);
            Assert.AreEqual(customAttributeMatchingRule.TypeName, deserializedRule.TypeName);
            Assert.AreEqual(customAttributeMatchingRule.SearchInheritanceChain, deserializedRule.SearchInheritanceChain);
        }

        [TestMethod]
        public void MatchingRuleHasTransientLifetime()
        {
            CustomAttributeMatchingRuleData customAttributeMatchingRule = new CustomAttributeMatchingRuleData("MatchesMyAttribure", typeof(InjectionConstructorAttribute).AssemblyQualifiedName, true);

            using (var container = new UnityContainer())
            {
                customAttributeMatchingRule.ConfigureContainer(container, "-test");
                var registration = container.Registrations.Single(r => r.Name == "MatchesMyAttribure-test");
                Assert.AreSame(typeof(IMatchingRule), registration.RegisteredType);
                Assert.AreSame(typeof(CustomAttributeMatchingRule), registration.MappedToType);
                Assert.AreSame(typeof(TransientLifetimeManager), registration.LifetimeManagerType);
            }
        }
    }
}
