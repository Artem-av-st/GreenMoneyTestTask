using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMoneyTestTask
{
    public class NumericCollectionsProcessor
    {
        /// <summary>
        /// Returns a collection of intersections of two collections and theirs[intersections] squares
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when at least one of the collections is null</exception>
        public IEnumerable<KeyValuePair<int,int>> GetIntersectionsAndSquares(IEnumerable<int> firstCollection, IEnumerable<int> secondCollection)
        {            
            return firstCollection.Intersect(secondCollection).Select(x => new KeyValuePair<int,int>(x, (int)Math.Pow(x,2)) );
        }        
    }
}
