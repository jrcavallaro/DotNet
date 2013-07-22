using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.LinkedList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			LinkedList list = new LinkedList();
			list.Add(new Node("1"));
			list.Add(new Node("2"));
			list.Add(new Node("3"));
			list.Add(new Node("4"));

			list.PrintNodes();
			Console.ReadKey();
		}

		public class Node
		{
			public object Data;
			public Node Next;
			
			public Node(object data)
			{
				Data = data;
			}
		}

		public class LinkedList
		{
			private Node _head;
			private Node _current;

			public void Add(Node node)
			{
				if (_head == null)
				{
					_head = node;
					_current = _head;			// reference in heap will still point to _head.
				}
				else
				{
					_current.Next = node;
					_current = _current.Next;
				}
			}

			public void PrintNodes()
			{
				Node traversal = _head;

				while (traversal != null)
				{
					Console.WriteLine(traversal.Data);
					traversal = traversal.Next;
				}
			}
		}
	}
}
