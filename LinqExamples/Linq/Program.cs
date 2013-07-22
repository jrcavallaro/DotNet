using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			var numsInPlace = numbers.Select((n, i) => new {Num = n, InPlace = (n == i)});

			Console.WriteLine("Number: In-place?");

			//numsInPlace.ToList().ForEach(n => );

		}
	}
}
