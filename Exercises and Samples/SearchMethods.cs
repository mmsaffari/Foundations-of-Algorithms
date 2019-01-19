using System;

namespace Exercises_and_Samples {
	public class SearchMethods {
		public static int BinarySearch_Recursive<T>(T[] input, T item, int lowerBound, int upperBound) where T : IComparable {
			if (lowerBound <= upperBound) {
				int mid = (lowerBound + upperBound) / 2;
				if (input[mid].CompareTo(item) == 0) {
					return mid;
				} else if (input[mid].CompareTo(item) > 0) {
					return BinarySearch_Recursive(input, item, lowerBound, mid - 1);
				} else {
					return BinarySearch_Recursive(input, item, mid + 1, upperBound);
				}
			} else {
				return -1;
			}
		}

		public static int BinarySearch<T>(T[] input, T item) where T : IComparable {
			int low = 0;
			int high = input.Length;

			while (low <= high) {
				int mid = (low + high) / 2;
				if (input[mid].CompareTo(item) == 0) {
					return mid;
				} else if (input[mid].CompareTo(item) > 0) {
					high = mid - 1;
				} else {
					low = mid + 1;
				}
			}
			return -1;
		}
	}
}
