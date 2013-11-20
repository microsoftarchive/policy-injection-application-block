// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.TestSupport.ObjectsUnderTest
{
    public interface IDal
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }

    public interface IMonitor
    {
        void Log(string message);
    }

    public class MockDal : MarshalByRefObject, IDal, IMonitor
    {
        private bool throwException;
        private double balance = 0.0;

        public bool ThrowException
        {
            get { return throwException; }
            set { throwException = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public int DoSomething(string x)
        {
            if (throwException)
                throw new InvalidOperationException("Catastrophic");
            return 42;
        }

        #region IDal Members

        public void Deposit(double amount)
        {
        }

        public void Withdraw(double amount)
        {
        }

        #endregion


        #region IMonitor Members

        public void Log(string message)
        {

        }

        #endregion

        [ApplyNoPolicies]
        public string SomethingCritical()
        {
            return "Don't intercept me";
        }
    }
}
