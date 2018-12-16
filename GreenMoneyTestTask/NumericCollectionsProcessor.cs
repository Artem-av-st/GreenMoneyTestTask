using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class NumericCollectionsProcessor
    {
        public IEnumerable<KeyValuePair<int,int>> GetIntersectionsAndSquares(IEnumerable<int> firstCollection, IEnumerable<int> secondCollection)
        {            
            return firstCollection?.Intersect(secondCollection).Select(x => new KeyValuePair<int,int>(x, (int)Math.Pow(x,2)) );
        }        
    }
}
