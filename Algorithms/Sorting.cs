using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Linq;

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

		public void MergeSort(int[] a)
		{
			int start = 0;
			int end = a.Length - 1;
			int mid = (start + end) / 2;
			mergeSort (a, start, mid);
			mergeSort (a, (mid +1), end);
			merge (a, start, (mid+1), end);
		}

		private void mergeSort(int[] a, int start, int end)
		{
			if(start < end)
			{
				int mid = (start + end) / 2;
				mergeSort (a, start, mid);
				mergeSort (a, (mid +1), end);
				merge (a, start, (mid+1), end);
			}
		}

		private void merge(int[] a, int start, int mid, int end)
		{
			if (end - start < 2)
			{
				int tempL = a [start];
				int tempR = a [end];
				if (a[start] <= a[end])
				{
					a [start] = tempL;
					a [end] = tempR;
				}
				else
				{
					a [start] = tempR;
					a [end] = tempL;
				}
				return;
			}

			int leftEnd = mid - 1;
			int tmpPos = 0;
			int numElements = (end - start + 1);
			int[] temp = new int[numElements];
			while ((start <= leftEnd) && (mid <= end))
			{
				if (a[start] <= a[mid])
					temp[tmpPos++] = a[start++];
				else
					temp[tmpPos++] = a[mid++];
			}
			while (start <= leftEnd)
				temp[tmpPos++] = a[start++];
			while (mid <= end)
				temp[tmpPos++] = a[mid++];

			var tempIterator = tmpPos - 1;
			for (int i = 0; i < numElements; i++)
			{
				a [end] = temp [tempIterator];
				end--;
				tempIterator--;
			}
		}

		int [] temp2 = new int[1000000];
		public void mergemethod(int [] numbers, int left, int mid, int right)
		{
			
			int i, left_end, num_elements, tmp_pos;
			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);
			while ((left <= left_end) && (mid <= right))
			{
				if (numbers[left] <= numbers[mid])
					temp2[tmp_pos++] = numbers[left++];
				else
					temp2[tmp_pos++] = numbers[mid++];
			}
			while (left <= left_end)
				temp2[tmp_pos++] = numbers[left++];
			while (mid <= right)
				temp2[tmp_pos++] = numbers[mid++];
			for (i = 0; i < num_elements; i++)
			{
				numbers[right] = temp2[right];
				right--;
			}

		}
		public void sortmethod(int [] numbers, int left, int right)
		{
			int mid;
			if (right > left)
			{
				mid = (right + left) / 2;
				sortmethod(numbers, left, mid);
				sortmethod(numbers, (mid + 1), right);
				mergemethod(numbers, left, (mid+1), right);
			}
		}
	}
}

