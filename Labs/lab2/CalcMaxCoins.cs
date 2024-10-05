using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
	public class CalcMaxCoins
	{
		// ф-ця для обчислення максимальної кількості монет для першого гравця
		public static int CalculateMaxCoins(int[] coins, int[] sum, int N, int K)
		{
			int[,] dp = new int[N + 1, K + 1];  // dp[i, x] - максимальна кількість монет з i-ї стопки, коли можна взяти до x стопок

			for (int i = N - 1; i >= 0; i--)
			{
				for (int x = 1; x <= K; x++)
				{
					for (int take = 1; take <= x && i + take <= N; take++)
					{
						dp[i, x] = Math.Max(dp[i, x], sum[i] - dp[i + take, Math.Min(K, take)]);
					}
				}
			}

			return dp[0, K]; 
		}
	}
}
