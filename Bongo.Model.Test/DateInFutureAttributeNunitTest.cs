using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Model.Test
{
    [TestFixture]
    public class DateInFutureAttributeNunitTest
    {
        [Test]
        [TestCase(100,ExpectedResult =true)]
        [TestCase(-100, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDateRange_Datevalidity(int addValues)
        {
            DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute(() => DateTime.Now);
            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addValues));
            return result;
        }

        [Test]
        //[TestCase(DateTime.Now,ExpectedResult =false)]
        public void DateValidator_NotValidDate_ValidationErrorMessage()
        {
            DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute(() => DateTime.Now);
            Assert.AreEqual("Date must be in the future", dateInFutureAttribute.ErrorMessage);
        }
    }
}