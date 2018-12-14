using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class RandomNumsGenerator
    {
        public IEnumerable<double> GetRandomNumbersWithFixedSum(double from, double to, int sum)
        {
            if(from != 0.0)
            {
                throw new ArgumentOutOfRangeException("from", "'from' values different from 0.0 are not supported.");
            }
            if(to < from)
            {
                throw new ArgumentOutOfRangeException("from", "'from' value cannot be greater or equal then 'to'.");
            }
            
            double dSum = sum;
            var intFrom = Convert.ToInt32(from * 10);
            var intTo = Convert.ToInt32(to * 10);
            var rnd = new Random();
            
            do
            {
                var num = from;
                if (dSum < to)
                {
                    intTo = Convert.ToInt32(dSum * 10);                    
                }
                
                num = ((double)rnd.Next(intFrom, intTo+1)) / 10;
                dSum -= num;
                dSum = Math.Round(dSum, 2);
                yield return num;

            } while (dSum != 0);
        }
    }
}
