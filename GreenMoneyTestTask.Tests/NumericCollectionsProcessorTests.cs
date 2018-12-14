using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GreenMoneyTestTask.Tests
{
    public class NumericCollectionsProcessorTests
    {
        NumericCollectionsProcessor processor = new NumericCollectionsProcessor();

        [Theory]
        [MemberData(nameof(PositiveData))]
        void GetIntersectionsAndSquares_positive_scenario(IEnumerable<int> firstCollection, IEnumerable<int> secondCollection, IEnumerable<KeyValuePair<int,int>> expectedCollection)
        {
            var result = processor.GetIntersectionsAndSquares(firstCollection, secondCollection).OrderBy(x => x.Key);

            Assert.Equal(expectedCollection, result);   
        }

        public static IEnumerable<object[]> PositiveData()
        {            
            yield return new object[] 
            {
                new[] { 1, 3, 5, 7 },
                new[] { 1, 2, 3, 4, 5 },
                new [] 
                {
                    new KeyValuePair<int,int>(1,1),
                    new KeyValuePair<int,int>(3,9),
                    new KeyValuePair<int,int>(5,25)
                }
            };

            yield return new object[]
            {
                new[] { 7, 3, 5, 2 },
                new[] { 1, 4, 5, 6, 7 },
                new []
                {
                    new KeyValuePair<int,int>(5,25),                    
                    new KeyValuePair<int,int>(7,49)
                }
            };
        }
    }
}
