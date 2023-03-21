using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUnitTest.BusinessLogic;
using Xunit;

namespace DemoUnitTest.XUnit
{

    public class CustomerTests
    {
        private Customer _customer;
        public CustomerTests()
        {

            _customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange


            //Act
            string result = _customer.CombineStrings("Paras", "Zalariya");

            //Assert.Throws<ArgumentException>(() => result);
            //Assert.That(() => _customer.CombineStrings("", "Zalariya"), Throws.ArgumentException.With.Message.EqualTo("FirstName Is required"));

            Assert.Multiple(() =>
            {
                //Assert
                Assert.NotNull(result);
                Assert.Equal("Paras Zalariya", result);
                //Assert.AreEqual(result, "Paras Zalariya");
                //Assert.That(result, Does.Contain("zalariya"));
                Assert.StartsWith("paras", result, StringComparison.OrdinalIgnoreCase);
                Assert.EndsWith("zalariya", result,  StringComparison.OrdinalIgnoreCase);
                Assert.Contains("par", result,  StringComparison.OrdinalIgnoreCase);
                Assert.Matches("^[A-Za-z ]+$", result);
            });


        }
        [Fact]
        public void CustomerDetail_InputOrderTotal_ReturnCustomerdetails()
        {
            //Arrange
            _customer.orderTotal = 50;
            //Act
            var result = _customer.Getcustomerdetails();
            //Assertion
            Assert.IsType<BasicCustomer>(result);
        }
    }
}
