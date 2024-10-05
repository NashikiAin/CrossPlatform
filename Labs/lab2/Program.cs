using lab2;
using System;
using System.IO;

class Program
{
	static void Main()
	{
		string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..", @"..", @"..", "input.txt");

		if (!File.Exists(inputFilePath))
		{
			Console.WriteLine($"Not found '{inputFilePath}'.");
			return;
		}

		var input = File.ReadAllText(inputFilePath).Split();


		int N = int.Parse(input[0]);
		if (N < 1 || N > 180)
		{
			Console.WriteLine("Invalid number of piles (N). 1 <= N <= 180 ");
			return;
		}

		// Перевірка, чи введена правильна кількість чисел для стопок монет
		if (input.Length < N + 2)  
		{
			Console.WriteLine("Invalid input. The number of coins in the piles is less than expected.");
			return;
		}

		int[] coins = new int[N];
		for (int i = 0; i < N; i++)
		{
			coins[i] = int.Parse(input[i + 1]);
			if (coins[i] < 1 || coins[i] > 20000)
			{
				Console.WriteLine($"Invalid number of coins in coin column {i + 1}. 1 < coins < 20000");
				return;
			}
		}

		int K = int.Parse(input[N + 1]);
		if (K < 1 || K > 80)
		{
			Console.WriteLine("Invalid value for K. 1 <= K <= 80");
			return;
		}

		// Обчислюємо залишкову кількість монет
		int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);

		// Обчислюємо максимальну кількість монет для першого гравця
		int maxCoins = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);

		Console.WriteLine("Now check the output file, there's an answer!");
		File.WriteAllText("OUTPUT.txt", maxCoins.ToString());
	}
}