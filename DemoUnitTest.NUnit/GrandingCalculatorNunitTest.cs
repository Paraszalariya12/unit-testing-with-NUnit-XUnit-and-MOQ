using DemoUnitTest.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.NUnit
{
    public class GrandingCalculatorNunitTest
    {
        GrandingCalculator grandingCalculator;

        [SetUp]
        public void Setup()
        {
            grandingCalculator = new();
        }


        [Test]
        [TestCase(95, 90)]//A
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
            Assert.That(result, Is.EqualTo("A"));
            //Assert.That(result, Is.EqualTo("B"));
            //Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]//A
        [TestCase(85, 95, ExpectedResult = "B")]//B
        [TestCase(65, 90, ExpectedResult = "C")]//C
        [TestCase(95, 65, ExpectedResult = "B")]//B
        [TestCase(65, 90, ExpectedResult = "C")]//C
        [TestCase(95, 55, ExpectedResult = "F")]//F
        [TestCase(65, 55, ExpectedResult = "F")]//F
        [TestCase(50, 90, ExpectedResult = "F")]//F
        public string ALLResultGrade_TwoIntegerInput_ReturnGradeString(int score, int Grade)
        {
            grandingCalculator.Score = score;
            grandingCalculator.AttendancePercentage = Grade;

            var result = grandingCalculator.GetGrade();
            return result;
        }
    }
}
