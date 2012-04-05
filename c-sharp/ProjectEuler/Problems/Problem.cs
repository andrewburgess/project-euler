using System;

namespace ProjectEuler.Problems
{
	public abstract class Problem
	{
		protected DateTime StartTime { get; set; }
		protected DateTime EndTime { get; set; }

        public virtual string Name { get { return string.Empty;  } }
        public virtual string Description { get { return string.Empty; } }

		public void Run()
		{
			StartTime = DateTime.Now;

			var result = Execute();

			EndTime = DateTime.Now;

			Console.WriteLine("Answer is: " + result);
			Console.WriteLine("Execution took: " + ((EndTime - StartTime).TotalMilliseconds / 1000.0) + " seconds");
		}

		public abstract string Execute();
	}
}