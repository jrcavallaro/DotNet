using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.SortedListvsDictionary
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("\nDictionary");
			var t1 = DateTime.Now.Ticks;
			Console.WriteLine(t1);

			var dict = new Dictionary<int, string>();

			for (var x = 1; x < 10000; x++)
			{
				dict.Add(x, x.ToString(CultureInfo.InvariantCulture));
			}

//			foreach (var d in dict.OrderBy(d => d.Key))
////			foreach (var d in dict)
//			{
//				Console.WriteLine(d);
//			}

			var t2 = DateTime.Now.Ticks;
			Console.WriteLine(t2);
			Console.WriteLine(t2 - t1);
			Console.WriteLine("----------------------------------------------------");


			var t3 = DateTime.Now.Ticks;
			Console.WriteLine(t3);

			var sortedList = new SortedList<int, string>();

			for (var x = 1; x < 10000; x++)
			{
				sortedList.Add(x, x.ToString(CultureInfo.InvariantCulture));
			}

			//Console.WriteLine("sorted list");
			//foreach (var sl in sortedList)
			//{
			//	Console.WriteLine(sl);
			//}

			var t4 = DateTime.Now.Ticks;
			Console.WriteLine(t4);
			Console.WriteLine(t4 - t3);

			Console.ReadKey();
		}
	}
}
