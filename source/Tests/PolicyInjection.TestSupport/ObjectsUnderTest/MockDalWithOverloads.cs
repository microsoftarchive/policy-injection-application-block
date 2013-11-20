// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.TestSupport.ObjectsUnderTest
{
    class MockDalWithOverloads : MarshalByRefObject
    {
        public int DoSomething(string s)
        {
            return 42;
        }

        [Tag("NullString")]
        public string DoSomething(int i)
        {
            return (i * 2).ToString();
        }
    }
}
