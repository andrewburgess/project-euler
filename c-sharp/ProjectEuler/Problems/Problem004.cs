using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem004 : Problem
    {
        public override string Name { get { return "Find the largest palindrome made from the product of two 3-digit numbers."; } }
        public override string Description { get { return "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.\n\nFind the largest palindrome made from the product of two 3-digit numbers."; } }

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