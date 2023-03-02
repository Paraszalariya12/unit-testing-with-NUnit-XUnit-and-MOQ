using DemoUnitTest.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.NUnit
{
    public class FiboNUniteTest
    {
        private Fibo _fibo;
        [SetUp]
        public void Setup()
        {
            _fibo = new Fibo();
        }

        [Test]
        public void GetFibo_InputoneInteger_ResultSeries()
        {
            List<int> expected = new List<int>() { 0 };
            var result = _fibo.GetFiboSeries();
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(expected));
            });
        }


        [Test]
        [TestCase(6)]
        public void GetFibo_InputoneInteger6_ResultSeries(int Maxnumb)
        {
            //Arrange
            List<int> expected = new List<int>() { 0, 1, 1, 2, 3, 5 };

            //Act
            _fibo.Range = Maxnumb;
            var result = _fibo.GetFiboSeries();

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.That(result, Does.Contain(3));
                Assert.That(result, Has.No.Member(4));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(expected));
            });
        }
    }
}
