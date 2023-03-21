using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic.Interface
{
    public interface ILogbook
    {
        public int LogServerity { get; set; }
        public string LogType { get; set; }
        void LogMessage(string message);
        bool LogBalanceAfterwithdraw(decimal balanceAfterWithdraw);
        bool LogToDB(String Message);
        string MessageWithReturnstr(string message);
        bool LogMessageWithOut(string message, out string Outputresult);
        bool logwithrefobject(ref Customer customer);
    }
}
