using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    /*
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
     * The sum of these multiples is 23.
     * 
     * Find the sum of all the multiples of 3 or 5 below 1000.
     * 
     * Answer: 233168
     * Execution Time: 0.002 seconds
     */
    public class Problem001 : Problem
    {
        public override string Name { get { return "Add all the natural numbers below one thousand that are multiples of 3 or 5."; } }
        public override string Description { get { return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\nFind the sum of all the multiples of 3 or 5 below 1000."; } }

        public override string Execute()
        {
            var result = 0;
            Parallel.For(0, 1000, i => { if (i % 3 == 0 || i % 5 == 0) Interlocked.Add(ref result, i); });
            return result.ToString();
        }
    }
}