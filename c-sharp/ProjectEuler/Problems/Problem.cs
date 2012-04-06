using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public abstract class Problem
    {
        protected DateTime StartTime { get; set; }
        protected DateTime EndTime { get; set; }

        public abstract string Name { get; }

        public void Run()
        {
            StartTime = DateTime.Now;

            var result = Execute();

            EndTime = DateTime.Now;

            Console.WriteLine("Answer is: " + result);
            Console.WriteLine("Execution took: " + ((EndTime - StartTime).TotalMilliseconds / 1000.0) + " seconds");
        }

        public abstract string Execute();

        protected Dictionary<long, int> PrimeFactors(long number)
        {
            var factors = new Dictionary<long, int>();
            for (var x = 2; number > 1; x++)
            {
                if (number % x == 0)
                {
                    var y = 0;
                    while (number % x == 0)
                    {
                        number /= x;
                        y++;
                    }

                    factors.Add(x, y);
                }
            }

            return factors;
        }

        protected List<long> GetPrimes(int limit)
        {
            var list = new List<long>() {2, 3};

            if (limit <= 2) return list.Take(limit).ToList();

            for (var i = 2; i < limit; i++)
            {
                //Calculate next prime
                var isPrime = false;

                for (var j = list.Last() + 1; isPrime == false; j++)
                {
                    var current = j;
                    Parallel.ForEach(list, (x, loopState) =>
                                               {
                                                   isPrime = true;
                                                   if (current % x == 0)
                                                   {
                                                       isPrime = false;
                                                       loopState.Break();
                                                   }
                                               });

                    if (isPrime)
                        list.Add(j);
                }
            }

            return list;
        }
    }
}