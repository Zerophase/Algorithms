using System;
using Algorithms;
using System.Net;
using System.Data.Linq;

namespace Algorithims
{
	class MainClass
	{
		private static Sorting sortingAlg = new Sorting();
		private static Searching searchAlg = new Searching();
		private static Addition additionAlg = new Addition();

		private static int[] valuesInsert = {1,2,3,4,5,6};
		private static int valueToFind = 7;
		private static int[] valuesSelection = {10, 20, 15, 18, 5, 4, 9};
		private static int[] valuesMegeSort = { 4, 15, 2, 1, 14, 8, 6, 3};

		private static byte[] bValue = { 1,0,1 };
		private static byte[] bValue2 = { 1,1 ,1};
		private static Binary firstBinaryNumber;
		private static Binary secondBinaryNumber;

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

			printAndOperate (valuesMegeSort, new Action <int[]>(sortingAlg.MergeSort));
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
