using Xunit;
namespace lab3.Tests
{
	public  class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			int[,] maze = {
				{ 2, 0, 0, 1, 1 },
				{ 0, 1, 0, 0, 1 },
				{ 1, 1, 0, 0, 1 },
				{ 0, 0, 0, 0, 1 },
				{ 3, 1, 0, 0, 1 }
			};
			int startX = 0, startY = 0, endX = 4, endY = 0, K = 1;

			FindShortPath.Find(maze, 5, 5, K, startX, startY, endX, endY);
			string output = File.ReadAllText("OUTPUT.txt");

			Assert.Equal("12", output); // Expected distance is 12
		}
		[Fact]
		public void Test2()
		{
			int[,] maze = {
				{ 2, 1, 3}
			};
			int startX = 0, startY = 0, endX = 0, endY = 2, K = 0;

			FindShortPath.Find(maze, 1, 3, K, startX, startY, endX, endY);
			string output = File.ReadAllText("OUTPUT.txt");

			Assert.Equal("-1", output); 
		}
		[Fact]
		public void Test3()
		{
			int[,] maze = {
				{ 2, 0, 1, 1 },
				{ 0, 0, 1, 0 },
				{ 0, 0, 1, 0 },
				{ 1, 0, 0, 3 }
			};
			int startX = 0, startY = 0, endX = 3, endY = 3, K = 1;

			FindShortPath.Find(maze, 4, 4, K, startX, startY, endX, endY);
			string output = File.ReadAllText("OUTPUT.txt");

			Assert.Equal("6", output); 
		}

		[Fact]
		public void Test4()
		{
			int[,] maze = {
				{ 2, 1, 3 },
				{ 0, 1, 0 },
				{ 0, 1, 1 }
			};
			int startX = 0, startY = 0, endX = 0, endY = 2, K = 1;

			FindShortPath.Find(maze, 3, 3, K, startX, startY, endX, endY);
			string output = File.ReadAllText("OUTPUT.txt");

			Assert.Equal("-1", output);
		}

		[Fact]
		public void Test5()
		{
			int[,] maze = {
				{ 2, 0, 0, 1 },
				{ 1, 0, 0, 1 },
				{ 1, 0, 0, 3 },
				{ 1, 1, 1, 1 }
			};
			int startX = 0, startY = 0, endX = 2, endY = 3, K = 2;

			FindShortPath.Find(maze, 4, 4, K, startX, startY, endX, endY);
			string output = File.ReadAllText("OUTPUT.txt");

			Assert.Equal("5", output); 
		}

		
	}
}