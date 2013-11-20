// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Tests.Configuration
{
    [TestClass]
    public class MemberNameMatchingRuleDataFixture : MatchingRuleDataFixtureBase
    {
        [TestMethod]
        public void CanSerializeTypeMatchingRule()
        {
            MemberNameMatchingRuleData memberNameMatchingRule =
                new MemberNameMatchingRuleData("MatchThis", new MatchData[]
                                                                {
                                                                    new MatchData("ToString"),
                                                                    new MatchData("GetHashCode", true),
                                                                    new MatchData("Get*", false)
                                                                });

            MemberNameMatchingRuleData deserializedRule = SerializeAndDeserializeMatchingRule(memberNameMatchingRule) as MemberNameMatchingRuleData;

            Assert.IsNotNull(deserializedRule);
            Assert.AreEqual(memberNameMatchingRule.Name, deserializedRule.Name);
            Assert.AreEqual(memberNameMatchingRule.Matches.Count, deserializedRule.Matches.Count);
            for (int i = 0; i < deserializedRule.Matches.Count; ++i)
            {
                AssertMatchDataEqual(memberNameMatchingRule.Matches[0],
                                     deserializedRule.Matches[0],
                                     "Match item {0} is incorrect", i);
            }
        }

        [TestMethod]
        public void MatchingRuleHasTransientLifetime()
        {
            MemberNameMatchingRuleData memberNameMatchingRule = new MemberNameMatchingRuleData("MatchThis");

            using (var container = new UnityContainer())
            {
                memberNameMatchingRule.ConfigureContainer(container, "-test");
                var registration = container.Registrations.Single(r => r.Name == "MatchThis-test");
                Assert.AreSame(typeof(IMatchingRule), registration.RegisteredType);
                Assert.AreSame(typeof(MemberNameMatchingRule), registration.MappedToType);
                Assert.AreSame(typeof(TransientLifetimeManager), registration.LifetimeManagerType);
            }
        }
    }
}
