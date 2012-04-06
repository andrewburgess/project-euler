using System;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem009 : Problem
    {
        public override string Name
        {
            get { return "Find the only Pythagorean triplet, {a, b, c}, for which a + b + c = 1000."; }
        }

        public override string Execute()
        {
            var val = 0l;
            Parallel.For(1, 1000, (a, loopState) =>
                                      {
                                          for (var b = a + 1; b <= 1000; b++)
                                          {
                                              if (val != 0) return;
                                              var c = 1000 - a - b;
                                              if (c < a || c < b) return;
                                              if (((a*a) + (b*b)) == (c*c))
                                              {
                                                  val = a*b*c;
                                                  loopState.Break();
                                                  break;
                                              }
                                          }
                                      });
            return val.ToString();
        }
    }
}