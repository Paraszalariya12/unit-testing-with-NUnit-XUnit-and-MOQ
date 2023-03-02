using DemoUnitTest.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic
{
    public class BankAcount
    {
        public decimal balance { get; set; }
        private ILogbook _logbook;
        public BankAcount(ILogbook logbook)
        {
            balance = 0;
            _logbook = logbook;
        }

        public bool deposite(decimal amount)
        {
            _logbook.LogMessage($"Amount {amount.ToString("N2")} is deposited in your account.");
            balance += amount;
            return true;
        }

        public bool withdraw(decimal amount)
        {
            balance -= amount;
            return true;
        }

        public decimal getBalance()
        {
            return balance;
        }
    }
}
