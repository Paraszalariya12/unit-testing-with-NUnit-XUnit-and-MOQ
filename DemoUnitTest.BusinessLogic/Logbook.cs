﻿using DemoUnitTest.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic
{
    public class Logbook : ILogbook
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
