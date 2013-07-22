using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.JoinSortedArrays
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var array1 = new int[] {1, 3, 5, 7, 9, 21};
			var array2 = new int[] {2, 4, 6, 8, 10, 11, 12, 19};

			var array3 = new int[14];

			var counter = 0;

			for (var x = 0; x < array2.Count(); x++)
			{
				for(var y = 0; y < array1.Count(); y++)
				{
					if (x < y)
					{
						array3[counter++] = array2[x];
						break;
					}
					else
					{
						array3[counter++] = array1[y];
						break;
					}
				}
			}

			foreach (var i in array3)
			{
				Console.WriteLine(i);
			}

			Console.ReadKey();
		}
	}
}
