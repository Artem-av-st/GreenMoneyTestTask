using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class RandomNumsGenerator
    {
        /// <summary>
        /// Returns a collection of random numbers between 'from' and 'to', whose sum is 
        /// equals to 'sum'
        /// </summary>
        /// <param name="from">At this momment supported only 0.0 value</param>
        /// <param name="to">Must be greater then 'from'</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if 'from' is differ from 0.0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if 'from' is greater then 'to'</exception>
        public IEnumerable<double> GetRandomNumbersWithFixedSum(double from, double to, int sum)
        {
            int numAfterDot = 1;
            if(from != 0.0)
            {
                throw new ArgumentOutOfRangeException("from", "'from' values different from 0.0 are not supported.");
            }
            if(to < from)
            {
                throw new ArgumentOutOfRangeException("from", "'from' value cannot be greater or equal then 'to'.");
            }
            
            double dSum = sum;
            var intFrom = Convert.ToInt32(from * numAfterDot * 10);
            var intTo = Convert.ToInt32(to * numAfterDot * 10);
            var rnd = new Random();
            
            do
            {
                var num = from;
                if (dSum < to)
                {
                    intTo = Convert.ToInt32(dSum * numAfterDot * 10);                    
                }
                
                num = ((double)rnd.Next(intFrom, intTo+1)) / numAfterDot / 10;
                dSum -= num;
                // Should round double values to avoid issues like *.99999999999997
                dSum = Math.Round(dSum, 2);
                yield return num;

            } while (dSum != 0);
        }
    }
}
