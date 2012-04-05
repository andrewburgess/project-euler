using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ProjectEuler.Problems;

namespace ProjectEuler
{
	public class Program
	{
		static void Main(string[] args)
		{
		    Console.WriteLine("        Project Euler solutions         ");
		    Console.WriteLine("----------------------------------------");
		    Console.WriteLine("by Andrew Burgess <andrew@deceptacle.com");
		    Console.WriteLine();

		    var problemClasses = GetProblems();

		    var list = problemClasses.Keys.OrderBy(x => x).ToList();
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + list[i]);
            }

            Problem currentProblem;

		    string input;
		    do
		    {
		        Console.Write("Enter problem number to load: ");
		        input = Console.ReadLine();

		        int num;
                if (int.TryParse(input, out num))
                {
                    if (num >= 1 && num <= list.Count)
                    {
                        var t = Assembly.GetExecutingAssembly().GetType(problemClasses[list[num - 1]]);
                        currentProblem = (Problem)Activator.CreateInstance(t);

                        Console.WriteLine("\n\nProblem Number: " + num);
                        Console.WriteLine(currentProblem.Name);
                        Console.WriteLine(string.Empty.PadRight(40, '-'));
                        Console.WriteLine(currentProblem.Description);
                        Console.WriteLine();
                        currentProblem.Run();
                        Console.WriteLine("\n\n");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Invalid problem number\n");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Input was not a number\n");
                }
		    } while (input != "quit" && input != "exit"); 
		}

        static IDictionary<string, string> GetProblems()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var ns = "ProjectEuler.Problems";

            var types = assembly.GetTypes().Where(x => String.Equals(x.Namespace, ns, StringComparison.Ordinal));
            return types.Where(x => x.Name != "Problem" && !x.Name.StartsWith("<>")).ToDictionary(x => x.Name, x => x.FullName);
        }
	}
}
