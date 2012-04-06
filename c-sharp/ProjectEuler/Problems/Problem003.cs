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
            var num = 600851475143;
            var search = (int) Math.Ceiling(Math.Sqrt(num));

            var max = -1;

            var factors = new List<int>();
            Parallel.For(3, search, x => { if (num % x == 0) factors.Add(x); });
            foreach (var val in factors.OrderByDescending(x => x))
            {
                if (val % 2 == 0) continue;
                var factorFound = false;
                for (var i = 3; i <= Math.Ceiling(Math.Sqrt(val)); i += 2)
                {
                    if (val%i != 0) continue;

                    factorFound = true;
                    break;
                }

                if (factorFound) continue;

                max = val;
                break;
            }

            return max.ToString();
        }
    }
}