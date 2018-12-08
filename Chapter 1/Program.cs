using System;

namespace Chapter_1 {
	class Program {
		static void Main(string[] args) {
			//General input variables used in different exercises.
			//متغیر های ورودی عمومی که در تمرینهای مختلف استفاده خواهند شد.
			int[] Array = new int[] { 11, 8, 70, 84, 65, 19, 39, 35, 88, 87, 86, 3, 74, 90, 2 };

			//Exercise 1:
			Console.WriteLine("Max: {0}", Max(Array));

		}

		static int Max(int[] Array) {
			int Max = Array[0];
			for (int i = 0; i < Array.Length; i++) {
				if (Array[i] > Max) {
					Max = Array[i];
				}
			}
			return Max;
		}
	}
}
