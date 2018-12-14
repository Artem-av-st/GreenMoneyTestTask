using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GreenMoneyTestTask.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void GetFizzBuzz_positive_scenario()
        {
            var fizz = "Green";
            var buzz = "Money";
            var from = 0;
            var to = 15;
            var expectedResult = new[] { "GreenMoney", "1", "2", "Green", "4", "Money", "Green", "7", "8", "Green", "Money", "11", "Green", "13", "14", "GreenMoney" };
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.GetFizzBuzz(from, to, fizz, buzz).ToArray();

            Assert.Equal(expectedResult, result);
        }
    }
}
