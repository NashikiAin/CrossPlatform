using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
	public class CalcPrefSum
	{
		// Функція для обчислення залишкової кількості монет у стопках
		public static int[] CalculateRemainingCoins(int[] coins, int N)
		{
			int[] sum = new int[N + 1];
			for (int i = N - 1; i >= 0; i--)
			{
				sum[i] = sum[i + 1] + coins[i];  // Сума монет від стопки i до кінця
			}
			return sum;
		}
	}
}
