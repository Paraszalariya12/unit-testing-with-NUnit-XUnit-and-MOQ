using DemoUnitTest.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.BusinessLogic
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }

        public double GetPrice(ICustomer customer)
        {
            if (customer.Isplatinum)
            {
                return Price * .8;
            }
            return Price;
        }
    }
}
