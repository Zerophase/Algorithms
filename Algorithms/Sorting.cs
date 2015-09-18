using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms
{
	public class Sorting
	{
		delegate bool del(int number, int key);
		public Sorting ()
		{
		}

		// TODO optimize
		public void InsertionSort(int[] a, SortOrder sortOrder)
		{
			del sort;
			switch (sortOrder)
			{
			case SortOrder.INCREASING:
				sort = delegate(int x, int key) 
				{
					return x > key;
				};
				break;
			case SortOrder.DECREASING:
				sort = delegate(int x, int key) 
				{
					return x < key;
				};
				break;
			default:
				sort = null;
				Console.WriteLine ("Error");
				break;
			}

			for (int j = 1; j < a.Length; j++) 
			{
				var key = a [j];
				// insert a[j] into the sorted sequence a[0...j -1]
				var i = j - 1;
				while (i > -1 && sort(a[i], key))
				{
					a [i + 1] = a [i];
					i = i - 1;
				}
				a [i + 1] = key;
			}
		}

		public void SelectionSort(int[] a)
		{
			for (int i = 0; i < a.Length - 1; i++)
			{
				var index = i;
				for (int j = i+1; j < a.Length; j++)
				{
					if (a [j] < a [index])
						index = j;
				}

				if (index != i)
				{
					var tmp = a [index];
					a [index] = a [i];
					a [i] = tmp;
				}
			}
		}
	}
}

