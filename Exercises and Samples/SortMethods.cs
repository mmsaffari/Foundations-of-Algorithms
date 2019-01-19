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
	}


}
