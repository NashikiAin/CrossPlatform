using lab2;
using lab3;
using lab5.Models;
using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace lab5.Controllers
{
	public class LabsController : Controller
	{
        [Authorize]
        public IActionResult Utils()
        {
            return View(new UtilsViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Utils(UtilsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int[] arr = Enumerable.Range(1, model.N).ToArray();
                    int count = 0;
                    lab1.Utils.Permute(arr, 0, model.K, ref count);

                    model.Count = count;

                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Помилка під час обчислення: {ex.Message}");
                }
            }

            return View(model);
        }


        [Authorize]
        public IActionResult CalcMaxCoins()
        {
            return View(new CalcMaxCoinsViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CalcMaxCoins(CalcMaxCoinsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int[] coins = model.CoinsString
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)  
                        .Select(coin =>
                        {
                            int parsedCoin;
                            if (int.TryParse(coin.Trim(), out parsedCoin))
                            {
                                return parsedCoin;
                            }
                            else
                            {
                                throw new FormatException("Неправильний формат coins");
                            }
                        })
                        .ToArray();

                    if (coins.Length > model.N)
                    {
                        ModelState.AddModelError("CoinsString", "Кількість монет не може бути більшою за кількість стопок (N).");
                        return View(model);
                    }

                    if (coins.Length != model.N)
                    {
                        ModelState.AddModelError("CoinsString", "Кількість монет повинна відповідати значенню N.");
                        return View(model);
                    }

                    int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, model.N);

                    int result = lab2.CalcMaxCoins.CalculateMaxCoins(coins, sum, model.N, model.K);

                    model.MaxCoins = result;

                    return View(model);
                }
                catch (FormatException)
                {
                    ViewData["InvalidInput"] = "Будь ласка, введіть монети у правильному форматі, розділені комами, або через пробіл (наприклад: 5,10,15  або через пробіл 5 10 15).";
                    return View(model);
                }
                catch (IndexOutOfRangeException ex)
                {
                    ViewData["InvalidInput"] = "Виникла помилка з індексами. Перевірте правильність введених даних.";
                    return View(model);
                }
            }

            return View(model);
        }

        [Authorize]
        public IActionResult FindShortPath()
        {
            return View(new FindShortPathViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult FindShortPath(FindShortPathViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string[] rows = model.MazeString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    int N = model.N;
                    int M = model.M;
                    int[,] maze = new int[N, M];


                    for (int i = 0; i < N; i++)
                    {
                        string[] cells = rows[i].Trim().Split(' ');
                        for (int j = 0; j < M; j++)
                        {
                            maze[i, j] = int.Parse(cells[j]);
                        }
                    }

                    int K = model.K;
                    int startX = model.StartX;
                    int startY = model.StartY;
                    int endX = model.EndX;
                    int endY = model.EndY;

                    lab3.FindShortPath.Find(maze, N, M, K, startX, startY, endX, endY);

                    var result = System.IO.File.ReadAllText("OUTPUT.txt");
                    model.ShortestPathDistance = result == "-1" ? (int?)null : int.Parse(result);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Помилка під час обчислення: {ex.Message}");
                }
            }

            return View(model);
        }
    }
}
