using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem003 : Problem
    {
        public override string Name { get { return "Find the largest prime factor of a composite number."; } }

        public override string Execute()
        {
            const long num = 600851475143l;

            var result = PrimeFactors(num).Keys.OrderBy(x => x).Last();

            return result.ToString();
        }
    }
}