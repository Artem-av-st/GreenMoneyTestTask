using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GreenMoneyTestTask.Tests
{
    public class RandomNumsGeneratorTests
    {
        RandomNumsGenerator generator = new RandomNumsGenerator();
        [Theory]
        [InlineData(0.0,0.6,1)]
        [InlineData(0.0, 2.6, 5)]
        [InlineData(0.0, 20.0, 25)]
        void GetRandomNumbersWithFixedSum_positive_scenario(double from, double to, int sum)
        {   
            var result = generator.GetRandomNumbersWithFixedSum(from, to, sum).ToArray();

            var resultSum = Math.Round(result.Sum(),10);           
            Assert.Equal(sum, resultSum);
        }
        [Fact]
        void GetRandomNumbersWithFixedSum_from_differs_then_zero_argumentOutOfRangeException()
        {
            var from = 0.1;
            var to = 1.0;
            var sum = 1;
            var expectedExceptionMessage = "'from' values different from 0.0 are not supported.";
            
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => generator.GetRandomNumbersWithFixedSum(from, to, sum).ToArray());

            Assert.Contains(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        void GetRandomNumbersWithFixedSum_from_is_greater_then_to_argumentOutOfRangeException()
        {
            var from = 0.0;
            var to = -1.0;
            var sum = 1;
            var expectedExceptionMessage = "'from' value cannot be greater or equal then 'to'.";

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => generator.GetRandomNumbersWithFixedSum(from, to, sum).ToArray());

            Assert.Contains(expectedExceptionMessage, exception.Message);
        }
    }
}
