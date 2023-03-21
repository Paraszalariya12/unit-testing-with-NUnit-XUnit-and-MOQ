using DemoUnitTest.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoUnitTest.XUnit
{
    public class FiboXUniteTest
    {
        private Fibo _fibo;
        public FiboXUniteTest()
        {
            _fibo = new Fibo();
        }

        [Fact]
        public void GetFibo_InputoneInteger_ResultSeries()
        {
            List<int> expected = new List<int>() { 0 };
            var result = _fibo.GetFiboSeries();
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.Equal(1, result.Count);
                Assert.Equal(result.OrderBy(a => a), result);
                Assert.True(result.SequenceEqual(expected));
            });
        }


        [Theory]
        [InlineData(6)]
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
                Assert.NotNull(result);
                Assert.Contains(3, result);
                Assert.DoesNotContain(4, result);
                Assert.Equal(6, result.Count);
                Assert.Equal(result.OrderBy(a => a), result);
                Assert.True(result.SequenceEqual(expected));
            });
        }
    }
}
