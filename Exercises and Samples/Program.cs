using System;

namespace Exercises_and_Samples {
	class Program {
		static void Main(string[] args) {
			Console.Write("Please enter a number: ");
			long N = Convert.ToInt64(Console.ReadLine());
			PrintNumbers(N);
		}


		static void PrintNumbers(long number) {
			while (number > 0) {
				Console.WriteLine(number % 10);
				number /= 10;
			}
		}
	}
}