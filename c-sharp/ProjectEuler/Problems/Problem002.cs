using System;

namespace ProjectEuler.Problems
{
    /*
     * Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
     * By starting with 1 and 2, the first 10 terms will be:
     * 
     *			1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
     *			
     * By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
     * find the sum of the even-valued terms.
     * 
     * Answer: 4613732
     * Execution Time: 0.001 seconds
     */
    public class Problem002 : Problem
    {
        public override string Name { get { return "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."; } }
        public override string Description { get { return "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:\n\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n\nBy considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."; } }

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