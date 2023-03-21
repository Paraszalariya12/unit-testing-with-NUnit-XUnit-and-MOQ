using DemoUnitTest.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic
{
    public class Logbook : ILogbook
    {
        public int LogServerity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterwithdraw(decimal balanceAfterWithdraw)
        {
            if (balanceAfterWithdraw >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public string MessageWithReturnstr(string message)
        {
            return message.ToLower();
        }

        public bool LogMessageWithOut(string message, out string Outputresult)
        {
            Outputresult = "Hello " + message;
            //return message.ToLower();
            return true;
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogToDB(string Message)
        {
            Console.WriteLine(Message);
            return true;
        }
        public bool logwithrefobject(ref Customer customer)
        {
            return true;
        }
    }
}
