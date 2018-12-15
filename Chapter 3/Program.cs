using System;
using System.Linq;

namespace Chapter_3 {
	class Program {
		static void Main(string[] args) {
			int
				n = 10,
				k = 3;
			System.Console.WriteLine("C({0}, {1}) = {2}", n, k, Combination_2D(n, k));
			System.Console.WriteLine("C({0}, {1}) = {2}", n, k, Combination(n, k));
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
			double[] mat = new double[k + 1 < 2 ? 2 : k + 1];
			mat[0] = 1;
			mat[1] = 1;
			for (int i = 2; i < n + 1; i++) {
				int halfWay = (int)Math.Ceiling((double)(i + 1) / 2);
				mat[halfWay - 1] += mat[halfWay - 2];
				for (int j = halfWay-2; j > 0; j--) {
					mat[j] += mat[j - 1];
				}
				Console.WriteLine("i={0}, k={1}, Matrix = {{ {2} }}", i, k, string.Join(", ", mat.Select(item => string.Format("{0,3}", item)).ToArray()));
			}
			return mat[k];
		}
	}
}
