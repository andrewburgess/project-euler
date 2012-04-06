using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem005 : Problem
    {
        public override string Name { get { return "What is the smallest number divisible by each of the numbers 1 to 20?"; } }
        public override string Description { get { return "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n\nWhat is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?"; } }

        public override string Execute()
        {
            var primes = new Dictionary<long, int> { {2, 1}, {3, 1}, {5, 1}, {7, 1}, {11, 1}, {13, 1}, {17, 1}, {19, 1} };

            foreach (var x in Enumerable.Range(1, 20).Where(x => primes.ContainsKey(x) == false))
            {
                var factors = PrimeFactors(x);
                foreach (var factor in factors)
                {
                    if (primes[factor.Key] < factor.Value)
                        primes[factor.Key] = factor.Value;
                }
            }

            return primes.Aggregate(1l, (current, kv) => current*(long) Math.Pow(kv.Key, kv.Value)).ToString();
        }
    }
}