using DemoUnitTest.BusinessLogic;
using DemoUnitTest.BusinessLogic.Interface;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoUnitTest.XUnit
{
  
    public class BankAccountXunitTest
    {
        private BankAcount _bankAcount;
        private Mock<ILogbook> _logbook;
        public BankAccountXunitTest()
        {
            //We use Moq for Pass fake interface object to bussiness Method.
            _logbook = new Mock<ILogbook>();
            _bankAcount = new BankAcount(_logbook.Object);
        }

        [Fact]
        public void AddBalance_Input100_Returnboolvalue()
        {
            var result = _bankAcount.deposite(100);
            Assert.True(result);
            Assert.Equal(100, _bankAcount.getBalance());
        }
        [Theory]
        //[TestCase(200, 100)]
        [InlineData(101, -2)]
        //[TestCase(50, 100)]
        public void BankWithdrowl_InputBalanceandWithdrawalAmount_ResultTrue(int Balance, int WithdrowAmount)
        {
            //_logbook.Setup(a => a.LogToDB(It.IsAny<string>())).Returns(true);
            _logbook.Setup(a => a.LogBalanceAfterwithdraw(It.Is<decimal>(a => a > 0))).Returns(true);
            _logbook.Setup(a => a.LogBalanceAfterwithdraw(It.IsInRange<decimal>(decimal.MinValue, Decimal.MinusOne, Moq.Range.Inclusive))).Returns(false);
            _bankAcount.deposite(Balance);
            var result = _bankAcount.withdraw(WithdrowAmount);
            Assert.True(result);
        }

        [Theory]
        [InlineData("HellO")]
        public void BankLogDummy_LogMockString_returnTrue(string Input)
        {
            string DesiredOutput = "hello";
            _logbook.Setup(a => a.MessageWithReturnstr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.Equal(_logbook.Object.MessageWithReturnstr(Input), DesiredOutput);
        }

        [Theory]
        [InlineData("Paras2")]
        public void BankLogDummy_LogStringWithOutPut_returnTrue(string Input)
        {
            string DesiredOutput = "hello";
            _logbook.Setup(a => a.LogMessageWithOut(It.IsAny<string>(), out DesiredOutput)).Returns(true);

            string result = "";
            //_logbook.Object.LogMessageWithOut(Input,out result);
            Assert.True(_logbook.Object.LogMessageWithOut("Ben", out result));
            Assert.Equal(result, DesiredOutput);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_returnTrue()
        {
            Customer customer = new Customer();
            Customer customerunused = new Customer();

            _logbook.Setup(u => u.logwithrefobject(ref customer)).Returns(true);

            Assert.False(_logbook.Object.logwithrefobject(ref customerunused));

            Assert.True(_logbook.Object.logwithrefobject(ref customer));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogTypeandSeverityMock_MockTest()
        {
            //In this Example How we can update Property Of Mock after it Setups
            Customer customer = new Customer();
            Customer customerunused = new Customer();

            _logbook.Setup(u => u.LogType).Returns("Warning");
            _logbook.Setup(u => u.LogServerity).Returns(10);

            //_logbook.SetupAllProperties();
            //_logbook.Object.LogServerity = 100;
            //_logbook.Object.LogType = "Error";

            Assert.Multiple(() =>
            {
                Assert.Equal("Warning", _logbook.Object.LogType);
                Assert.Equal(10,_logbook.Object.LogServerity);
            });

            //CallBack
            string LogMessage = "Hello, ";
            _logbook.Setup(a => a.LogToDB(It.IsAny<String>())).Returns(true).Callback((string str) => LogMessage += str);

            _logbook.Object.LogToDB("Paras");

            Assert.Equal("Hello, Paras", LogMessage);

            //CallBack With Integer
            int LogMessageCount = 1;
            _logbook.Setup(a => a.LogToDB(It.IsAny<String>())).Returns(true).Callback(() => LogMessageCount++);

            _logbook.Object.LogToDB("Paras");
            _logbook.Object.LogToDB("Hiral");

            Assert.Equal(3, LogMessageCount);
        }

        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            BankAcount bankAcount = new BankAcount(_logbook.Object);
            bankAcount.deposite(100);
            Assert.Equal(100, bankAcount.getBalance());

            _logbook.Verify(u => u.LogMessage(It.IsAny<String>()), Times.Exactly(2));
            _logbook.VerifySet(u => u.LogServerity = 100, Times.Exactly(1));
            _logbook.VerifyGet(u => u.LogServerity, Times.Exactly(1));
        }

    }
}
