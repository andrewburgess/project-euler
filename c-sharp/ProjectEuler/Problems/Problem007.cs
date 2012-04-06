using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem007 : Problem
    {
        public override string Name
        {
            get { return "Find the 10001st prime."; }
        }

        public override string Execute()
        {
            return GetPrimes(10001)[10000].ToString();
        }
    }
}