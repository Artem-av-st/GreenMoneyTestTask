using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class FizzBuzz
    {
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
