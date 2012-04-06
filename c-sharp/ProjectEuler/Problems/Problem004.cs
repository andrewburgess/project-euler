using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem004 : Problem
    {
        public override string Name { get { return "Find the largest palindrome made from the product of two 3-digit numbers."; } }

        public override string Execute()
        {
            var palindromes = new List<int>();

            //TODO: This can probably be tightened up
            Parallel.For(100, 999, x =>
                                       {
                                           for (var i = 100; i <= 999; i++)
                                           {
                                               if (IsPalindrome(x * i))
                                                   palindromes.Add(x*i);
                                           }
                                       });
            return palindromes.OrderByDescending(x => x).First().ToString();
        }

        private bool IsPalindrome(int input)
        {
            return input.ToString() == new string(input.ToString().Reverse().ToArray());
        }
    }
}