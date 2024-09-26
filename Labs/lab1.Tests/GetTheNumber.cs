using Xunit;
namespace lab1.Tests
{
	public class GetTheNumber
	{
		[Fact]
		public void GetTheNumber_N3_K1_Test1()
		{
			// Arrange
			int N = 3;
			int K = 1;
			int expectedCount = 2; 
			int count = 0;
			int[] arr = new int[N];

			for (int i = 0; i < N; i++)
			{
				arr[i] = i + 1;
			}

			// Act
			Utils.Permute(arr, 0, K, ref count);

			// Assert
			Assert.Equal(expectedCount, count);
		}

		[Fact]
		public void GetTheNumber_N4_K2_Test2()
		{
			// Arrange
			int N = 4;
			int K = 2;
			int expectedCount = 12; 
			int count = 0;
			int[] arr = new int[N];

			for (int i = 0; i < N; i++)
			{
				arr[i] = i + 1;
			}

			// Act
			Utils.Permute(arr, 0, K, ref count);

			// Assert
			Assert.Equal(expectedCount, count);
		}

		[Fact]
		public void GetTheNumber_N5_K4_Test3()
		{
			// Arrange
			int N = 5;
			int K = 4;
			int expectedCount = 120;
			int count = 0;
			int[] arr = new int[N];

			for (int i = 0; i < N; i++)
			{
				arr[i] = i + 1;
			}

			// Act
			Utils.Permute(arr, 0, K, ref count);

			// Assert
			Assert.Equal(expectedCount, count);
		}

		[Fact]
		public void GetTheNumber_N7_K3_Test4()
		{
			// Arrange
			int N = 7;
			int K = 3;
			int expectedCount = 428; 
			int count = 0;
			int[] arr = new int[N];

			for (int i = 0; i < N; i++)
			{
				arr[i] = i + 1;
			}

			// Act
			Utils.Permute(arr, 0, K, ref count);

			// Assert
			Assert.Equal(expectedCount, count);
		}

		[Fact]
		public void GetTheNumber_N8_K2_Test5()
		{
			// Arrange
			int N = 8;
			int K = 2;
			int expectedCount = 88; // Adjust the expected count based on actual computation
			int count = 0;
			int[] arr = new int[N];

			for (int i = 0; i < N; i++)
			{
				arr[i] = i + 1;
			}

			// Act
			Utils.Permute(arr, 0, K, ref count);

			// Assert
			Assert.Equal(expectedCount, count);
		}

	}
}