using System;
using Algorithms;
using System.Net;
using System.Data.Linq;
using System.Diagnostics;

namespace Algorithims
{
	class MainClass
	{
		private static Sorting sortingAlg = new Sorting();
		private static Searching searchAlg = new Searching();
		private static Addition additionAlg = new Addition();

		private static int[] valuesInsert = {6,5,4,3,2,1};
		private static int valueToFind = 7;
		private static int[] valuesSelection = {10, 20, 15, 18, 5, 4, 9};
		private static int[] valuesMegeSort = new int[1000000];
		private static int[] valuesMergeSort2 = new int[1000000];

		private static byte[] bValue = { 1,0,1 };
		private static byte[] bValue2 = { 1,1 ,1};
		private static Binary firstBinaryNumber;
		private static Binary secondBinaryNumber;

		private static Random random = new Random ();

		public static void Main (string[] args)
		{

			printAndOperate (valuesInsert, new Action<int[], SortOrder>(sortingAlg.InsertionSort));

			Console.WriteLine ("Searching for value: " + valueToFind);
			var foundValue = searchAlg.LinearSearch (valuesInsert, valueToFind);
			Console.WriteLine ("Element found: " + foundValue);

			firstBinaryNumber = new Binary (bValue);
			secondBinaryNumber = new Binary (bValue2);
			var sum = additionAlg.BinaryAddition (firstBinaryNumber, secondBinaryNumber);
			Console.WriteLine ("Binary Addition gives: " + sum);

			printAndOperate (valuesSelection, new Action<int[]>(sortingAlg.SelectionSort));

			for (int i = 0; i < valuesMegeSort.Length; i++)
			{
				valuesMergeSort2[i] = valuesMegeSort [i] = random.Next (0, 100000);
			}

			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			sortingAlg.MergeSort (valuesMegeSort);
			//printAndOperate (valuesMegeSort, new Action <int[]>(sortingAlg.MergeSort));
			stopwatch.Stop ();
			Console.WriteLine ("Time elapsed MergeSort : {0}", stopwatch.Elapsed);

			stopwatch.Restart ();
			sortingAlg.sortmethod (valuesMergeSort2, 0, valuesMergeSort2.Length - 1);
			stopwatch.Stop ();
			Console.WriteLine ("Time elapsed MergeSort2: {0}", stopwatch.Elapsed);

			int zeroCount = 0;
			for (int i = 0; i < valuesMegeSort.Length; i++)
			{
				if (valuesMegeSort[i] == 0)
				{
					zeroCount++;
				}
			}
			Console.WriteLine ("valuesMergeSort zero count: {0}", zeroCount);
			int zeroCount2 = 0;
			for (int i = 0; i < valuesMergeSort2.Length; i++)
			{
				if (valuesMergeSort2[i] == 0)
				{
					zeroCount2++;
				}
			}
			Console.WriteLine ("valuesMergeSort2 zero count: {0}", zeroCount2);
			for (int i = 0; i < valuesMegeSort.Length; i++)
			{
				if (valuesMegeSort [i] != valuesMergeSort2 [i])
				{
					Console.WriteLine ("Values do not match.");
					return;
				}
					
			}

			Console.WriteLine ("Values Match.");
		}

		private static void printAndOperate(int[] values, Action<int[]> algorithim)
		{
			for (int i = 0; i < values.Length; i++)
				Console.Write (values [i] + ", ");
			Console.WriteLine ();
			algorithim.Invoke (values);
			for (int i = 0; i < values.Length; i++)
				Console.Write (values[i] + ", ");
			Console.WriteLine ();
		}
		private static void printAndOperate(int[] values, Action<int[], SortOrder> algorithim)
		{
			for (int i = 0; i < values.Length; i++)
				Console.Write (values [i] + ", ");
			Console.WriteLine ();
			algorithim.Invoke (values, SortOrder.DECREASING);
			for (int i = 0; i < valuesInsert.Length; i++)
				Console.Write (valuesInsert[i] + ", ");
			Console.WriteLine ();
		}
	}
}
