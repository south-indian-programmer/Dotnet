using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DataStructures
{
	internal class LinkedListDemos
	{

		public void traverse(LLNode head)
		{
			while (head.next != null)
			{
				Console.WriteLine(head.value);
				head = head.next;
			}
		}
		public static void Main(string[] args)
		{
			LinkedListDemos linkedListDemos = new LinkedListDemos();
			LLNode head = new LLNode(1);
			LLNode n1 = new LLNode(2);
			LLNode n2 = new LLNode(3);
			LLNode n3 = new LLNode(4);
			LLNode n4 = new LLNode(5);
			head.next = n1;
			n1.next = n2;
			n2.next = n3;
			n3.next = n4;			
			linkedListDemos.traverse(head);
		}
	}
	class LLNode
	{
		public int value { get; set; } = 0;
		public LLNode next { get; set; } = null;
		public LLNode(int v)
		{
			value = v;
		}
	}
}
