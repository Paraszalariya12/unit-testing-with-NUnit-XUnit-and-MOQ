using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic.Interface
{
    public interface ICustomer
    {
        int orderTotal { get; set; }
        bool Isplatinum { get; set; }
        CustomerType Getcustomerdetails();
        string CombineStrings(string FirstName, String LastName);
    }
}
