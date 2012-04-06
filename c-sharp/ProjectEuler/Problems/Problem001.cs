using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem001 : Problem
    {
        public override string Name { get { return "Add all the natural numbers below one thousand that are multiples of 3 or 5."; } }

        public override string Execute()
        {
            var result = 0;
            Parallel.For(0, 1000, i => { if (i % 3 == 0 || i % 5 == 0) Interlocked.Add(ref result, i); });
            return result.ToString();
        }
    }
}