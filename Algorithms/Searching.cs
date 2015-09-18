using System;

namespace Algorithms
{
	public class Searching
	{
		public Searching ()
		{
		}

		public int? LinearSearch(int[] a, int target)
		{
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] == target)
				{
					return a [i];
				}
			}
			return null;
		}
	}
}

