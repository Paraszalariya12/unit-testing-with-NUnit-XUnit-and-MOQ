using DemoUnitTest.BusinessLogic;
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
    public class BankAccountNunitTest
    {
        private BankAcount _bankAcount;
        [SetUp]
        public void Setup()
        {
            //We use Moq for Pass fake interface object to bussiness Method.
            var _logbook = new Mock<ILogbook>();
            _bankAcount = new BankAcount(_logbook.Object);
        }

        [Test]
        public void AddBalance_Input100_Returnboolvalue()
        {
            var result = _bankAcount.deposite(100);
            Assert.IsTrue(result);
            Assert.That(_bankAcount.getBalance(), Is.EqualTo(100));
        }
    }
}
