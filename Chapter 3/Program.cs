using System;
using System.Linq;

namespace Chapter_3 {
	class Program {
		static void Main(string[] args) {
			//int
			//	n = 1,
			//	k = 0;
			//Console.WriteLine("C({0}, {1}) = {2}", n, k, Combination_2D(n, k));
			//Console.WriteLine("C({0}, {1}) = {2}", n, k, Combination(n, k));

			WeightedGraph wg = new WeightedGraph(NodeCount: 5);
			wg.GenerateRandomGraph();
			wg.PrettyPrint();
		}

		static double Combination_2D(int n, int k) {
			double[,] mat = new double[n + 1, k + 1];
			for (int i = 0; i < n + 1; i++) {
				for (int j = 0; j < k + 1 && j <= i; j++) {
					if (i == j || j == 0) {
						mat[i, j] = 1;
					} else {
						mat[i, j] = mat[i - 1, j - 1] + mat[i - 1, j];
					}
				}
			}
			return mat[n, k];
		}

		static double Combination(int n, int k) {
			if (n < 0 || k > n || k < 0) { throw new NotSupportedException(); }

			if (k > n / 2) { k = n - k; }
			double[] mat = new double[k < 1 ? 2 : k + 1];
			mat[0] = 1;
			mat[1] = 1;

			for (int i = 2; i < n + 1; i++) {
				int halfWay = i / 2;
				if (halfWay <= k) {
					mat[halfWay] += mat[halfWay - 1];
				}
				if (halfWay + i % 2 <= k) {
					mat[halfWay + i % 2] = mat[halfWay];
				}
				int headStart = halfWay - 1 < k ? halfWay - 1 : k;
				for (int j = headStart; j > 0; j--) {
					mat[j] += mat[j - 1];
				}
				Console.WriteLine("i={0,2}, k={1,2}, Matrix = {{ {2} }}", i, k, string.Join(", ", mat.Select(item => string.Format("{0,3}", item)).ToArray()));
			}
			return mat[k];
		}
	}
}
