using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Algorithms.Searching
{
	internal class BinarySearching
	{
		public static void Main(string[] args)
		{

			int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
			int idx = binSearching(x, 7);
			Console.WriteLine(idx);
		}
		static int binSearching(int[] arr, int x)
		{
			int result = Int32.MinValue;
			int low = 0, high = arr.Length - 1;
			while (low <= high)
			{
				int mid = (low + high) / 2;
				if (arr[mid] == x)
					return mid;
				if (arr[mid] < x)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}
			return result;
		}
	}
}
