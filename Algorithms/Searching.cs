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

		public int BinarySearch(int[] a, int low, int high, int target)
		{

			int mid = high /2;
			while( low < high) 
			{
				if(target > a[mid])
					low = mid + 1;
				else if(target < a[mid])
					high = mid;
				else
					break;

				mid = low + ((high - low) / 2);
			}

			return mid;
		}
	}
}

