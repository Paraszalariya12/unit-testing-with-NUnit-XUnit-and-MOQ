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
            _logbook.LogMessage("Test");
            _logbook.LogServerity = 100;
            var result = _logbook.LogServerity;
            balance += amount;
            return true;
        }

        public bool withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                _logbook.LogToDB($"Withdrawl Amount: {amount.ToString("N2")}");
                balance -= amount;
                return _logbook.LogBalanceAfterwithdraw(balance);
            }
            return _logbook.LogBalanceAfterwithdraw(balance - amount);
        }

        public decimal getBalance()
        {
            return balance;
        }
    }
}
