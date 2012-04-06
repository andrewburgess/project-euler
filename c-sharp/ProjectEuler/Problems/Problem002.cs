using System;

namespace ProjectEuler.Problems
{
    public class Problem002 : Problem
    {
        public override string Name { get { return "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."; } }

        public override string Execute()
        {
            var result = Fibonacci(1, 2);

            return result.ToString();
        }

        private int Fibonacci(int first, int second)
        {
            if (first >= 4000000 || second >= 4000000)
                return 0;

            var next = first + second;

            return second%2 == 0 ? second + Fibonacci(second, next) : Fibonacci(second, next);
        }
    }
}