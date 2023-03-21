using DemoUnitTest.BusinessLogic;
using Xunit;

namespace DemoUnitTest.XUnit
{

    public class CalculationXUnitTest
    {
       

        [Fact]
        public void AddNumber_TwoInteger_GetCorrectAddition()
        {
            //Arrange
            Calculation calculation = new();
            //Act
            int result = calculation.Addition(10, 20);

            //Assert
            Assert.Equal(30,result);
        }
        [Theory]
        [InlineData(11)]
        [InlineData(21)]
        [InlineData(23)]
        public void AddNumber_OneInteger_GetNumberIsOdd(int a)
        {
            //Arrange
            Calculation calculation = new();

            //Act
            bool result = calculation.CheckOddNumber(a);

            //Assert(Result should be true)
            Assert.True(result);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(22)]
        public void AddNumber_OneInteger_GetNumberIsEven(int a)
        {
            //Arrange
            Calculation calculation = new();

            //Act
            bool result = calculation.CheckEventNumber(a);

            //Assert(Result should be true)
            Assert.True(result);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(13, true)]
        [InlineData(18, false)]
        public void isOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedresult)
        {
            Calculation calculation = new();
            var result = calculation.CheckOddNumber(a);
            Assert.Equal(expectedresult, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculation calculation = new();
            double result = calculation.doubleAddition(a, b);
            //Actual Result should be 15.9 but if you add .with(.1) then it allow us 0.1 value up and down(15.8 and 16.0 also)
            Assert.Equal(15.9, result, 2);
        }

        [Fact]
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
                Assert.Equal(Expectedresult, result);

                //Result set have 7 number in list using Classic Model
                Assert.Contains(7, result);

                //Result list contains 5 using Constraint Model
                Assert.Contains(5, result);

                //result should not empty
                Assert.NotEmpty(result);

                //Matching Count Of Expected and result
                Assert.Equal(3, result.Count);

                //Check 6 is not member of result
                Assert.DoesNotContain(6, result);

                //Check Order Of Generic List Asc-Desc
                Assert.Equal(result.OrderBy(a => a), result);

                //check all Values are Unique. Is not Exists in Xunit
                //Assert.That(result, Is.Unique);
            });
        }
        [Theory]
        [InlineData(10)]
        public void ValidateRange_InputInt_ReturnValidNumberOfRange(int number)
        {
            Assert.InRange(number, 1, 10);
        }

    }
}