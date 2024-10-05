using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DataStructures.Graphs
{
	internal class GraphDemos
	{

	}
	class GraphTraverse
	{
		public static void Main(string[] args)
		{
			int V = 6;
			Graph g = new Graph(V);
			g.AddEdge(1, 2);
			g.AddEdge(2, 3);
			g.AddEdge(3, 4);
			g.AddEdge(4, 5);
			g.AddEdge(5, 6);
			g.AddEdge(6, 1);
			g.AddEdge(1, 5);
			g.AddEdge(2, 4);
			int[] vis = Enumerable.Repeat(0, V + 1).ToArray();
			Dfs(g, 1, vis);
            Console.WriteLine("************************************************");
            vis = Enumerable.Repeat(0, V + 1).ToArray();			
			Bfs(g, 1, vis);
		}
		static void Dfs(Graph g, int r, int[] vis)
		{
			vis[r] = 1;
			Console.WriteLine(r);
			foreach (var i in g.adjList[r])
			{
				if (vis[i] == 0)
					Dfs(g, i, vis);
			}
		}
		static void Bfs(Graph g, int r, int[] vis)
		{
			List<int> q = new List<int>();
			q.Add(r);
			vis[r] = 1;
			while (q.Count > 0)
			{
				int n = q.First();
                Console.WriteLine(n);
                q.RemoveAt(0);
				foreach (var i in g.adjList[n])
				{
					if (vis[i] != 1)
					{
						vis[i]= 1;
						q.Add(i);
					}
				}
			}
		}
	}
	class Graph
	{
		public List<List<int>> adjList = null;
		public Graph(int v)
		{
			adjList = new List<List<int>>();
			for (int i = 0; i <= v; i++)
			{
				adjList.Add(new List<int>());
			}
		}
		public void AddEdge(int u, int v)
		{
			adjList[u].Add(v);
			adjList[v].Add(u);
		}
	}
	class WGraph
	{
		List<List<Tuple<int, int>>> adjList = null;
		public WGraph(int v)
		{
			adjList = new List<List<Tuple<int, int>>>(v);
			for (int i = 0; i <= v; i++)
			{
				adjList[i] = new List<Tuple<int, int>>();
			}
		}
		public void AddEdge(int u, int v, int w)
		{
			adjList[u].Add(new(v, w));
			adjList[v].Add(new(u, w));
		}
	}
}
