using DemoUnitTest.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoUnitTest.MSTest
{
    [TestClass]
    public class CalculationMSTest
    {
        [TestMethod]
        public void AddNumber_TwoInteger_GetCorrectAddition()
        {
            //Arrange
            Calculation calculation = new();
            //Act
            int result = calculation.Addition(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}