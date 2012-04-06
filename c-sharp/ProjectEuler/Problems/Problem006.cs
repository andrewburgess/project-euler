using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem006 : Problem
    {
        public override string Name { get { return "What is the difference between the sum of the squares and the square of the sums?"; } }

        public override string Execute()
        {
            var sumOfSquares = Enumerable.Range(1, 100).Aggregate(1l, (current, next) => current + (next*next));
            var squareOfSums = (long) Math.Pow(Enumerable.Range(1, 100).Sum(x => x), 2);

            return (squareOfSums - sumOfSquares).ToString();
        }
    }
}