using lab1;
using lab2;
using lab3;

namespace LabsLibrary
{
	public class RunnerLabs
	{
		public void RunLab1(string inputFilePath, string outputFilePath)
		{
			string[] lines = File.ReadLines(inputFilePath).Take(2).ToArray();

			if (!File.Exists(inputFilePath))
			{
				Console.WriteLine($"Not found '{inputFilePath}'.");
				return;
			}

			var input = File.ReadAllLines(inputFilePath);
			var parts = input[0].Split();

			if (!int.TryParse(parts[0], out int N) || !int.TryParse(parts[1], out int K))
			{
				Console.WriteLine("Invalid input. N and K must be integers.");
				return;
			}

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

		public void RunLab2(string inputFilePath, string outputFilePath)
		{
			string[] lines = File.ReadLines(inputFilePath).Take(2).ToArray();

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

		public void RunLab3(string inputFilePath, string outputFilePath)
		{
			string[] lines = File.ReadLines(inputFilePath).ToArray();

			if (!File.Exists(inputFilePath))
			{
				Console.WriteLine($"File '{inputFilePath}' not found.");
				return;
			}

			var input = File.ReadAllLines(inputFilePath);

			// Check if the first line has the right format
			if (input.Length < 1 || input[0].Split().Length != 3)
			{
				Console.WriteLine("Invalid input format in the first line.");
				return;
			}

			var firstLine = input[0].Split();

			// Validate K, N, and M
			if (firstLine.Length < 3 ||
				!int.TryParse(firstLine[0], out int K) || K < 0 || K > 5 ||
				!int.TryParse(firstLine[1], out int N) || N < 1 || N > 20 ||
				!int.TryParse(firstLine[2], out int M) || M < 1 || M > 20)
			{
				Console.WriteLine("Invalid input for K, N, or M. K must be between 0 and 5, and N and M must be natural numbers not exceeding 20.");
				return;
			}

			// Reading maze
			int[,] maze = new int[N, M];
			int startX = -1, startY = -1, endX = -1, endY = -1;

			for (int i = 0; i < N; i++)
			{
				// Check enough lines in the input file for the maze
				if (i + 1 >= input.Length)
				{
					Console.WriteLine($"Not enough lines for the maze. Expected {N} lines, but found {i}.");
					return;
				}
				var line = input[i + 1].Split();

				// Validate maze row length
				if (line.Length != M)
				{
					Console.WriteLine($"Line {i + 1} must contain exactly {M} integers. (delete useless spaces!)");
					return;
				}

				for (int j = 0; j < M; j++)
				{
					if (!int.TryParse(line[j], out maze[i, j]) || (maze[i, j] < 0 || maze[i, j] > 3))
					{
						Console.WriteLine($"Invalid value '{line[j]}' at maze position ({i}, {j}). Expected values: 0, 1, 2, or 3.");
						return;
					}
					if (maze[i, j] == 2)
					{
						if (startX != -1 || startY != -1) // Check for multiple start points
						{
							Console.WriteLine("There should be exactly one starting cell (2) in the maze.");
							return;
						}

						startX = i;
						startY = j;
					}
					else if (maze[i, j] == 3)
					{
						if (endX != -1 || endY != -1) // Check for multiple end points
						{
							Console.WriteLine("There should be exactly one ending cell (3) in the maze.");
							return;
						}
						endX = i;
						endY = j;
					}
				}
			}

			// Check if start and end points were found
			if (startX == -1 || startY == -1 || endX == -1 || endY == -1)
			{
				Console.WriteLine("Start (2) and end (3) points must be defined in the maze.");
				return;
			}
			FindShortPath.Find(maze, N, M, K, startX, startY, endX, endY);

			Console.WriteLine("Now u can check your output file!)");
		}
	}
}