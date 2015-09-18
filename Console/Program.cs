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

		private static byte[] bValue = { 1,0,1 };
		private static byte[] bValue2 = { 1,1 ,1};
		private static Binary firstBinaryNumber;
		private static Binary secondBinaryNumber;

		public static void Main (string[] args)
		{
			for (int i = 0; i < valuesInsert.Length; i++)
				Console.Write (valuesInsert[i] + ", ");
			Console.WriteLine ();
			sortingAlg.InsertionSort(valuesInsert, SortOrder.DECREASING);

			for (int i = 0; i < valuesInsert.Length; i++)
				Console.Write (valuesInsert[i] + ", ");
			Console.WriteLine ();
			Console.WriteLine ("Searching for value: " + valueToFind);
			var foundValue = searchAlg.LinearSearch (valuesInsert, valueToFind);
			Console.WriteLine ("Element found: " + foundValue);

			firstBinaryNumber = new Binary (bValue);
			secondBinaryNumber = new Binary (bValue2);
			var sum = additionAlg.BinaryAddition (firstBinaryNumber, secondBinaryNumber);
			Console.WriteLine ("Binary Addition gives: " + sum);
		
			for (int i = 0; i < valuesSelection.Length; i++)
				Console.Write (valuesSelection[i] + ", ");
			Console.WriteLine ();
			sortingAlg.SelectionSort (valuesSelection);
			for (int i = 0; i < valuesSelection.Length; i++)
				Console.Write (valuesSelection[i] + ", ");
		}
	}
}
