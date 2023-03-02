using DemoUnitTest.BusinessLogic;

namespace DemoUnitTest.NUnit
{
    [TestFixture]
    public class CalculationNUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void AddNumber_TwoInteger_GetCorrectAddition()
        {
            //Arrange
            Calculation calculation = new();
            //Act
            int result = calculation.Addition(10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(30));
        }
        [Test]
        [TestCase(11)]
        [TestCase(21)]
        [TestCase(23)]
        public void AddNumber_OneInteger_GetNumberIsOdd(int a)
        {
            //Arrange
            Calculation calculation = new();

            //Act
            bool result = calculation.CheckOddNumber(a);

            //Assert(Result should be true)
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(22)]
        public void AddNumber_OneInteger_GetNumberIsEven(int a)
        {
            //Arrange
            Calculation calculation = new();

            //Act
            bool result = calculation.CheckEventNumber(a);

            //Assert(Result should be true)
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(13, ExpectedResult = true)]
        [TestCase(18, ExpectedResult = false)]
        public bool isOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculation calculation = new();
            return calculation.CheckOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculation calculation = new();
            double result = calculation.doubleAddition(a, b);
            //Actual Result should be 15.9 but if you add .with(.1) then it allow us 0.1 value up and down(15.8 and 16.0 also)
            Assert.That(result, Is.EqualTo(16.0).Within(.1));
        }

        [Test]
        public void OddRanger_InputMinMaxRange_ReturnAllvalidOddNumberRanger()
        {
            //Arrange
            Calculation calculation = new();
            List<int> Expectedresult = new List<int>() { 5, 7, 9 };

            //act
            List<int> result = calculation.GotOddRangeValues(5, 10);
            
            //Assert .multiple is ude to execute all Assert statement and return list of error message in single execution.

            
            Assert.Multiple(() =>
            {
                //Assertion
                Assert.That(result, Is.EquivalentTo(Expectedresult));

                //Result set have 7 number in list using Classic Model
                Assert.Contains(7, result);

                //Result list contains 5 using Constraint Model
                Assert.That(result, Does.Contain(5));

                //result should not empty
                Assert.That(result, Is.Not.Empty);

                //Matching Count Of Expected and result
                Assert.That(result.Count, Is.EqualTo(3));

                //Check 6 is not member of result
                Assert.That(result, Has.No.Member(6));

                //Check Order Of Generic List Asc-Desc
                Assert.That(result, Is.Ordered);

                //check all Values are Unique.
                Assert.That(result, Is.Unique);
            });
        }
        [Test]
        [TestCase(10)]
        public void ValidateRange_InputInt_ReturnValidNumberOfRange(int number)
        {
            Assert.That(number, Is.InRange(1, 10));
        }

    }
}