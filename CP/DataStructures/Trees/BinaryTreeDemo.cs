using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DataStructures.Trees
{
	internal class BinaryTreeDemo
	{
		public static void Main(string[] args)
		{
			BinaryNode root=MakeTree();
			Console.WriteLine("-----------Preorder-------------");
			PrintTreePreOrder(root);
			Console.WriteLine("-----------Inorder-------------");
			PrintTreeInOrder(root);
			Console.WriteLine("-----------Postorder-------------");
			PrintTreePostOrder(root);
			Console.WriteLine("-----------levelorder-------------");
			PrintTreeLevelOrder(root);
		}
		static BinaryNode MakeTree()
		{
			BinaryNode n1 = new BinaryNode(1);
			BinaryNode n2 = new BinaryNode(2);
			BinaryNode n3 = new BinaryNode(3);
			BinaryNode n4 = new BinaryNode(4);
			BinaryNode n5 = new BinaryNode(5);
			BinaryNode n6 = new BinaryNode(6);
			BinaryNode n7 = new BinaryNode(7);
			n1.Left = n2;
			n1.Right = n3;
			n2.Left = n4;
			n2.Right = n5;
			n3.Left = n6;
			n3.Right = n7;
			return n1;
		}

		static void PrintTreePreOrder(BinaryNode root)
		{
			if(root == null) { return; }
            Console.WriteLine(root.Value);
            PrintTreePreOrder(root.Left);
			PrintTreePreOrder(root.Right);
		}
		static void PrintTreeInOrder(BinaryNode root)
		{
			if (root == null) { return; }
			PrintTreeInOrder(root.Left);
			Console.WriteLine(root.Value);
			PrintTreeInOrder(root.Right);
		}
		static void PrintTreePostOrder(BinaryNode root)
		{

			if (root == null) { return; }
			PrintTreePostOrder(root.Left);
			PrintTreePostOrder(root.Right);
			Console.WriteLine(root.Value);
		}
		static void PrintTreeLevelOrder(BinaryNode root)
		{
			List<BinaryNode> q=new List<BinaryNode>() { root}; 
			while (q.Count > 0)
			{
				BinaryNode tmp=q.First();
				q.RemoveAt(0);
                Console.WriteLine(tmp.Value);
				if(tmp.Left!=null)
					q.Add(tmp.Left);
				if(tmp.Right!=null)
					q.Add(tmp.Right);
            }
		}
	}
	class BinaryNode
	{
		public int Value;
		public BinaryNode Left { get; set; }
		public BinaryNode Right { get; set; }
		public BinaryNode(int v)
		{
			Value = v;
			Left = null;
			Right = null;
		}
	}
}
