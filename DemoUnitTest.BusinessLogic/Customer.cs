using DemoUnitTest.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic
{
    public class Customer: ICustomer
    {
        public int orderTotal { get; set; }
        public bool Isplatinum { get; set; }

        public Customer()
        {
            Isplatinum = false;
        }

        public string CombineStrings(string FirstName, String LastName)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("FirstName Is required");
            }

            return $"{FirstName} {LastName}";
        }

        public CustomerType Getcustomerdetails()
        {
            if (orderTotal<100)
            {
                return new BasicCustomer();
            }

            Isplatinum = true;
            return new PremiumCustomer();
        }

    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }

    public class PremiumCustomer : CustomerType { }
}
