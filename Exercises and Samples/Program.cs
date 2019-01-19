using System;

namespace Exercises_and_Samples {
	class Program {
		static void Main(string[] args) {
			//Console.Write("Please enter a number: ");
			//long N = Convert.ToInt64(Console.ReadLine());
			//PrintNumbers(N);

			//int[] List = BubbleSort(new int[] { 10, 41, 15, 132, 102, 23, 265, 176, 90 });
			//int Number = Convert.ToInt32(Console.ReadLine());
			//Console.WriteLine("Index of {0} in the List is {1}", Number, BinarySearch_Recursive(Number, List, 0, List.Length));

			int[] List = new int[] { 10, 41, 15, 132, 102, 23, 265, 176, 90 ,10};
			Console.WriteLine("UnSorted: [{0}]", string.Join(", ", List));
			//List = SortMethods.InsertionSort(List);
			//Console.WriteLine("Insertion Sorted: [{0}]", string.Join(", ", List));
			List = SortMethods.MergeSort(List);
			Console.WriteLine("Merge Sorted: [{0}]", string.Join(", ", List));


			//for (int i = 0; i < List.Length; i++) {
			//	int item = List[i];
			//	Console.WriteLine("Index of {0} in the list is: {1}", item, SearchMethods.BinarySearch_Recursive(List, item, 0, List.Length));
			//	Console.WriteLine("Index of {0} in the list is: {1}", item, SearchMethods.BinarySearch(List, item));
			//}

		}

		static void PrintNumbers(long number) {
			while (number > 0) {
				Console.WriteLine(number % 10);
				number /= 10;
			}
		}

		static int SequentialSearch(int n, int[] array) {
			for (int i = 0; i < array.Length; i++) {
				if (array[i] == n) {
					return i;
				}
			}
			return -1;
		}

		static int BinarySearch(int n, int[] array) {
			int low = 0;
			int high = array.Length;

			while (low <= high) {
				int mid = (low + high) / 2;
				if (n == array[mid]) {
					return mid;
				} else if (n < array[mid]) {
					high = mid;
				} else {
					low = mid;
				}
			}
			return -1;
		}

		static int BinarySearch_Recursive(int n, int[] array, int low, int high) {
			if (high - low <= 1) {
				if (n == array[low]) {
					return low;
				}
				return -1;
			}
			int mid = (low + high) / 2;
			if (n == array[mid]) {
				return mid;
			} else if (n < array[mid]) {
				return BinarySearch_Recursive(n, array, low, mid);
			} else {
				return BinarySearch_Recursive(n, array, mid, high);
			}
		}

		static int[] BubbleSort(int[] array) {
			for (int i = array.Length - 1; i >= 0; i--) {
				bool swapped = false;
				for (int j = 0; j < i; j++) {
					if (array[j] > array[j + 1]) {
						int temp = array[j + 1];
						array[j + 1] = array[j];
						array[j] = temp;
						swapped = true;
					}
				}
				if (!swapped) {
					break;
				}
			}
			return array;

		}

	}
}