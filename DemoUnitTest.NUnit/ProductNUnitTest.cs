﻿using DemoUnitTest.BusinessLogic;
using DemoUnitTest.BusinessLogic.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.NUnit
{
    [TestFixture]
    public class ProductNUnitTest
    {


        [Test]
        public void GetProductPrice_PlatinumUser_returnpricewith20discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(a => a.Isplatinum).Returns(false);

            Product product = new Product() { Price = 50 };

            var result=product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));

        }
    }
}
