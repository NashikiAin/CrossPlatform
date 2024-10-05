using Xunit;

namespace lab2.Tests
{
	public class GetMaxCoinsTests
	{
		[Fact]
		public void Test1()
		{
			int[] coins = { 4, 9, 1 };
			int K = 3;
			int N = coins.Length;
			int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
			int expected = 14; // Expected maximum coins
			int actual = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Test2()
		{
			int[] coins = { 1, 2, 2, 7 };
			int K = 3;
			int N = coins.Length;
			int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
			int expected = 5; // Expected maximum coins
			int actual = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Test3()
		{
			int[] coins = { 3, 4, 8, 1, 7 };
			int K = 2;
			int N = coins.Length;
			int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
			int expected = 18; // Expected maximum coins
			int actual = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Test4()
		{
			int[] coins = { 10, 1, 2, 3 };
			int K = 2;
			int N = coins.Length;
			int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
			int expected = 12; // Adjust according to game logic
			int actual = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Test5()
		{
			int[] coins = { 5, 5, 5, 5, 5 };
			int K = 3;
			int N = coins.Length;
			int[] sum = CalcPrefSum.CalculateRemainingCoins(coins, N);
			int expected = 15; // Adjust according to game logic
			int actual = CalcMaxCoins.CalculateMaxCoins(coins, sum, N, K);
			Assert.Equal(expected, actual);
		}
	}
}