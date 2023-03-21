using DemoUnitTest.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoUnitTest.XUnit
{
    public class GrandingCalculatorXunitTest
    {
        GrandingCalculator grandingCalculator;

        //[SetUp]
        public GrandingCalculatorXunitTest()
        {
            grandingCalculator = new();
        }


        [Theory]
        [InlineData(95, 90)]//A
        //[TestCase(85, 95)]//B
        //[TestCase(65, 90)]//C
        //[TestCase(95, 65)]//B
        //[TestCase(65, 90)]//C
        //[TestCase(95, 55)]//F
        //[TestCase(65, 55)]//F
        //[TestCase(50, 90)]//F

        public void ResultGrade_TwoIntegerInput_ReturnGradeString(int score, int Grade)
        {
            grandingCalculator.Score = score;
            grandingCalculator.AttendancePercentage = Grade;

            var result = grandingCalculator.GetGrade();

            //Assert.That(result, Is.EqualTo("F"));
            Assert.Equal("A", result);
            //Assert.That(result, Is.EqualTo("B"));
            //Assert.That(result, Is.EqualTo("C"));
        }

        [Theory]
        [InlineData(95, 90, "A")]//A
        [InlineData(85, 95, "B")]//B
        [InlineData(65, 90, "C")]//C
        [InlineData(95, 65, "B")]//B
        [InlineData(95, 55, "F")]//F
        [InlineData(65, 55, "F")]//F
        [InlineData(50, 90, "F")]//F
        public void ALLResultGrade_TwoIntegerInput_ReturnGradeString(int score, int Grade,string ExpectedResult)
        {
            grandingCalculator.Score = score;
            grandingCalculator.AttendancePercentage = Grade;

            var result = grandingCalculator.GetGrade();
            Assert.Equal($"{ExpectedResult}", result);
        }
    }
}
