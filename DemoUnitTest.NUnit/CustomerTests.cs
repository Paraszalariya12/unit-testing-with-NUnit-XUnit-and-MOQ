using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUnitTest.BusinessLogic;
using NUnit.Framework.Internal;

namespace DemoUnitTest.NUnit
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer _customer;
        [SetUp] public void SetUp() {

            _customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            

            //Act
            string result=_customer.CombineStrings("Paras", "Zalariya");


            Assert.That(() => _customer.CombineStrings("", "Zalariya"), Throws.ArgumentException.With.Message.EqualTo("FirstName Is required"));

            Assert.Multiple(() =>
            {
                //Assert
                Assert.IsNotNull(result);
                Assert.That(result, Is.EqualTo("Paras Zalariya"));
                //Assert.AreEqual(result, "Paras Zalariya");
                //Assert.That(result, Does.Contain("zalariya"));
                Assert.That(result, Does.StartWith("paras").IgnoreCase);
                Assert.That(result, Does.EndWith("zalariya").IgnoreCase);
                Assert.That(result, Does.Contain("par").IgnoreCase);
                Assert.That(result, Does.Match("^[A-Za-z ]+$"));
            });


        }
        [Test]
        public void CustomerDetail_InputOrderTotal_ReturnCustomerdetails()
        {
            //Arrange
            _customer.orderTotal= 50;
            //Act
            var result=_customer.Getcustomerdetails();
            //Assertion
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
    }
}
