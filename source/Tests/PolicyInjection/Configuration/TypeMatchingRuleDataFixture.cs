// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Tests.Configuration
{
    [TestClass]
    public class TypeMatchingRuleDataFixture : MatchingRuleDataFixtureBase
    {
        [TestMethod]
        public void CanSerializeTypeMatchingRule()
        {
            TypeMatchingRuleData typeMatchingRule = new TypeMatchingRuleData("RuleName",
                                                                             new MatchData[]
                                                                                 {
                                                                                     new MatchData("System.String"),
                                                                                     new MatchData("mydataobject", true),
                                                                                     new MatchData("Foo")
                                                                                 });

            TypeMatchingRuleData deserializedRule = SerializeAndDeserializeMatchingRule(typeMatchingRule) as TypeMatchingRuleData;

            Assert.IsNotNull(deserializedRule);
            Assert.AreEqual(typeMatchingRule.Name, deserializedRule.Name);
            Assert.AreEqual(typeMatchingRule.Matches.Count, deserializedRule.Matches.Count);
            for (int i = 0; i < typeMatchingRule.Matches.Count; ++i)
            {
                AssertMatchDataEqual(typeMatchingRule.Matches[i],
                                     deserializedRule.Matches[i],
                                     "The match at index {0} is incorrect", i);
            }
        }

        [TestMethod]
        public void MatchingRuleHasTransientLifetime()
        {
            TypeMatchingRuleData ruleData = new TypeMatchingRuleData("RuleName", "System.Int32");

            using (var container = new UnityContainer())
            {
                ruleData.ConfigureContainer(container, "-test");
                var registration = container.Registrations.Single(r => r.Name == "RuleName-test");
                Assert.AreSame(typeof(IMatchingRule), registration.RegisteredType);
                Assert.AreSame(typeof(TypeMatchingRule), registration.MappedToType);
                Assert.AreSame(typeof(TransientLifetimeManager), registration.LifetimeManagerType);
            }
        }
    }
}
