using System;
using System.Linq;

namespace Exercises_and_Samples {
	public class SortMethods {
		public static T[] InsertionSort<T>(T[] input) where T : IComparable {
			T[] result = input.Clone() as T[];
			for (int i = 1; i < result.Length; i++) {
				T key = result[i];
				int j = i - 1;
				while (j > 0 && result[j].CompareTo(key) > 0) {
					result[j + 1] = result[j--];
				}
				result[j + 1] = key;
			}
			return result;
		}

		public static T[] MergeSort<T>(T[] input) where T : IComparable {
			int n = input.Length;

			if (n > 1) {
				int h = n / 2;
				T[] U = MergeSort(input.Take(h).ToArray());
				T[] V = MergeSort(input.Skip(h).ToArray());

				T[] result = new T[U.Length + V.Length];
				int uIdx = 0;
				int vIdx = 0;
				int rIdx = 0;
				while (uIdx < U.Length || vIdx < V.Length) {
					result[rIdx++] = U[uIdx].CompareTo(V[vIdx]) < 0 ? U[uIdx++] : V[vIdx++];
					if (uIdx == U.Length) {
						for (int i = vIdx; i < V.Length; i++) {
							result[rIdx++] = V[vIdx++];
						}
					}
					if (vIdx == V.Length) {
						for (int i = uIdx; i < U.Length; i++) {
							result[rIdx++] = U[uIdx++];
						}
					}
				}
				return result;
			}

			return input;
		}

		public static T[] QuickSort<T>(T[] input) where T : IComparable {
			T[] result = input.Clone() as T[];
			QuickSort(result, 0, result.Length - 1);
			return result;
		}
		private static void QuickSort<T>(T[] input, int low, int high) where T : IComparable {
			if (low < high) {
				int q = Partition(input, low, high);
				if (q > 1) { QuickSort(input, low, q - 1); }
				if (q + 1 < high) { QuickSort(input, q + 1, high); }
			}
		}
		private static int Partition<T>(T[] input, int low, int high) where T : IComparable {
			T x = input[low];
			int i = low + 1;
			int j = high;
			do {
				while (i <= high && input[i].CompareTo(x) < 0) { i++; }
				while (j >= low && input[j].CompareTo(x) > 0) { j--; }
				if (i < j) { Swap(ref input[i], ref input[j]); }
			} while (i < j);
			Swap(ref input[low], ref input[j]);
			return j;
		}
		private static void Swap<T>(ref T v1, ref T v2) {
			T temp = v1;
			v1 = v2;
			v2 = temp;
		}
	}


}
