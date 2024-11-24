using lab1;
using lab2;
using lab3;
using System;
using System.IO;
using System.Linq;

namespace LabsLibrary
{
    public class RunnerLabs
    {
        public string RunLab1(string inputFilePath)
        {
            string[] lines = File.ReadLines(inputFilePath).Take(2).ToArray();

            if (!File.Exists(inputFilePath))
            {
                return $"Not found '{inputFilePath}'.";
            }

            var input = File.ReadAllLines(inputFilePath);
            var parts = input[0].Split();

            if (!int.TryParse(parts[0], out int N) || !int.TryParse(parts[1], out int K))
            {
                return "Invalid input. N and K must be integers.";
            }

            if (K > N || N > 9 || K < 0 || N < 1)
            {
                return "Invalid values. Ensure that K <= N <= 9.";
            }

            int[] numbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                numbers[i] = i + 1;
            }

            int count = 0;
            Utils.Permute(numbers, 0, K, ref count);

            File.WriteAllText("OUTPUT.TXT", count.ToString());
            return $"Answer written to OUTPUT.TXT with the result: {count}";
        }


        public string RunLab2(string inputFilePath)
        {
            string[] lines = File.ReadLines(inputFilePath).Take(2).ToArray();

            if (!File.Exists(inputFilePath))
            {
                return $"Not found '{inputFilePath}'.";
            }

            var input = File.ReadAllText(inputFilePath).Split();

            int N = int.Parse(input[0]);
            if (N < 1 || N > 180)
            {
                return "Invalid number of piles (N). 1 <= N <= 180.";
            }

            if (input.Length < N + 2)
            {
                return "Invalid input. The number of coins in the piles is less than expected.";
            }

            int[] coins = new int[N];
            for (int i = 0; i < N; i++)
            {
                coins[i] = int.Parse(input[i + 1]);
                if (coins[i] < 1 || coins[i] > 20000)
                {
                    return $"Invalid number of coins in coin column {i + 1}. 1 < coins < 20000.";
                }
            }

            int K = int.Parse(input[N + 1]);
            if (K < 1 || K > 80)
            {
                return "Invalid value for K. 1 <= K <= 80.";
            }

            int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
            int maxCoins = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);

            File.WriteAllText("OUTPUT.txt", maxCoins.ToString());
            return $"Answer written to OUTPUT.txt with the result: {maxCoins}";
        }


        public string RunLab3(string inputFilePath)
        {
            string[] lines = File.ReadLines(inputFilePath).ToArray();

            if (!File.Exists(inputFilePath))
            {
                return $"File '{inputFilePath}' not found.";
            }

            var input = File.ReadAllLines(inputFilePath);

            if (input.Length < 1 || input[0].Split().Length != 3)
            {
                return "Invalid input format in the first line.";
            }

            var firstLine = input[0].Split();

            if (firstLine.Length < 3 ||
                !int.TryParse(firstLine[0], out int K) || K < 0 || K > 5 ||
                !int.TryParse(firstLine[1], out int N) || N < 1 || N > 20 ||
                !int.TryParse(firstLine[2], out int M) || M < 1 || M > 20)
            {
                return "Invalid input for K, N, or M. K must be between 0 and 5, and N and M must be natural numbers not exceeding 20.";
            }

            int[,] maze = new int[N, M];
            int startX = -1, startY = -1, endX = -1, endY = -1;

            for (int i = 0; i < N; i++)
            {
                if (i + 1 >= input.Length)
                {
                    return $"Not enough lines for the maze. Expected {N} lines, but found {i}.";
                }

                var line = input[i + 1].Split();

                if (line.Length != M)
                {
                    return $"Line {i + 1} must contain exactly {M} integers. (delete useless spaces!)";
                }

                for (int j = 0; j < M; j++)
                {
                    if (!int.TryParse(line[j], out maze[i, j]) || (maze[i, j] < 0 || maze[i, j] > 3))
                    {
                        return $"Invalid value '{line[j]}' at maze position ({i}, {j}). Expected values: 0, 1, 2, or 3.";
                    }

                    if (maze[i, j] == 2)
                    {
                        if (startX != -1 || startY != -1)
                        {
                            return "There should be exactly one starting cell (2) in the maze.";
                        }

                        startX = i;
                        startY = j;
                    }
                    else if (maze[i, j] == 3)
                    {
                        if (endX != -1 || endY != -1)
                        {
                            return "There should be exactly one ending cell (3) in the maze.";
                        }
                        endX = i;
                        endY = j;
                    }
                }
            }

            if (startX == -1 || startY == -1 || endX == -1 || endY == -1)
            {
                return "Start (2) and end (3) points must be defined in the maze.";
            }

            FindShortPath.Find(maze, N, M, K, startX, startY, endX, endY);

            return "Maze solved successfully! Check the output for the result.";
        }
    }
}