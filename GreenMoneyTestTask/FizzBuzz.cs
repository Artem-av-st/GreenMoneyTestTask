using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class FizzBuzz
    {
        /// <summary>
        /// Counting from 'from' to 'to', and every time a number is divisible by 3 returns 'fizz', 
        /// every time a number is divisible by 5 return 'buzz' and every time a number is divisible 
        /// by 3 and 5, returns 'Fizz'+'buzz' instead of the number. If none of the conditions are matched, 
        /// then returns a number.
        /// </summary>       
        public IEnumerable<string> GetFizzBuzz(int from, int to, string fizz, string buzz)
        {
            var nums = Enumerable.Range(from, to+1);

            foreach (var num in nums)
            {
                if (num % 3 == 0)
                {
                    if (num % 5 == 0)
                    {
                        yield return fizz + buzz;
                        continue;
                    }
                    yield return fizz;
                    continue;
                }
                else if (num % 5 == 0)
                {
                    yield return buzz;
                    continue;
                }
                
                yield return num.ToString();                
            }
        }
    }
}
