using lab1;
using System;
using System.IO;

class Program
{
	static void Main()
	{
		string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..", @"..", @"..", "input.txt");

		// Check if the input file exists
		if (!File.Exists(inputFilePath))
		{
			Console.WriteLine($"Not found '{inputFilePath}'.");
			return;
		}

		var input = File.ReadAllLines(inputFilePath);
		var parts = input[0].Split();

		if (parts.Length != 2)
		{
			Console.WriteLine("Invalid input format. Try again. \nFor example: 3 1 (with space but only between two numbers)! ");
			return;
		}

		// n та к повинні бути цілими числами
		if (!int.TryParse(parts[0], out int N) || !int.TryParse(parts[1], out int K))
		{
			Console.WriteLine("Invalid input. N and K must be integers.");
			return;
		}

		// Перевірка на відповідність умовам задачі
		if (K > N || N > 9 || K < 0 || N < 1)
		{
			Console.WriteLine("Invalid values. Ensure that K <= N <= 9.");
			return;
		}


		int[] numbers = new int[N];
		for (int i = 0; i < N; i++)
		{
			numbers[i] = i + 1;
		}


		int count = 0;

		Utils.Permute(numbers, 0, K, ref count);

        Console.WriteLine("Now check the output file, there's an answer!");
        File.WriteAllText("OUTPUT.TXT", count.ToString());
	}
}
