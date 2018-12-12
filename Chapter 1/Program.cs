using System;

namespace Chapter_1 {
	class Program {
		static void Main(string[] args) {
			//General input variables used in different exercises.
			//متغیر های ورودی عمومی که در تمرینهای مختلف استفاده خواهند شد.
			int[] Array = new int[] { 11, 8, 70, 84, 65, 19, 39, 35, 88, 87, 86, 3, 74, 90, 2 };

			//Exercise 1:
			Console.WriteLine("Max: {0}", Max(Array));

			//Functions Introduction:
			// معرفی توابع
			int[] A = new int[] { 342, 329, 616, 131, 249, 254, 898, 398, 968, 403, 143, 288, 313, 636, 267 };
			int[] B = new int[] { 81, 470, 831, 232, 432, 989, 58, 998, 587, 321, 725, 330, 632 };
			int[] C = new int[] { 890, 313, 786, 354, 508, 787, 515, 608, 51, 15, 116 };

			Console.WriteLine("Max(A) = {0}", Max(A));
			Console.WriteLine("Min(A) = {0}", Min(A));
			Console.WriteLine("Max(B) = {0}", Max(B));
			Console.WriteLine("Min(B) = {0}", Min(B));
			Console.WriteLine("Max(C) = {0}", Max(C));
			Console.WriteLine("Min(C) = {0}", Min(C));

			for (int i = 1; i < 6; i++) {
				Console.WriteLine("{0}th smallest: {1}", i, FindkthSmallest(Array, i));
			}

		}

		// Exercise 1:
		static int Max(int[] Array) {
			int Max = Array[0];
			for (int i = 0; i < Array.Length; i++) {
				if (Array[i] > Max) {
					Max = Array[i];
				}
			}
			return Max;
		}

		//Needed for exercise 2:
		static int Min(int[] Array) {
			int Min = Array[0];
			for (int i = 0; i < Array.Length; i++) {
				if (Array[i] < Min) {
					Min = Array[i];
				}
			}
			return Min;
		}

		//exercise 2:
		static int FindkthSmallest(int[] Array, int k) {
			int kthMin = Min(Array);
			for (int level = 0; level < k - 1; level++) {
				int levelMin = Max(Array);
				for (int i = 0; i < Array.Length; i++) {
					if (Array[i] > kthMin && Array[i] < levelMin) {
						levelMin = Array[i];
					}
				}
				kthMin = levelMin;
			}
			return kthMin;
		}

	}
}
