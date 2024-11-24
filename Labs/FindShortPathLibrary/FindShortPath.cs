namespace FindShortPathLibrary
{
    public static class FindShortPath
    {
        public static void Find(int[,] maze, int N, int M, int K, int startX, int startY, int endX, int endY)
        {

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };
            var queue = new Queue<(int x, int y, int dir, int rightTurns, int distance)>();
            var visited = new bool[N, M, 4, K + 1];


            for (int d = 0; d < 4; d++)
            {
                queue.Enqueue((startX, startY, d, 0, 0));
                visited[startX, startY, d, 0] = true;
            }

            while (queue.Count > 0)
            {
                var (x, y, dir, rightTurns, dist) = queue.Dequeue();

                if (x == endX && y == endY)
                {
                    // Выводим текущую клетку как правильный ход
                    File.WriteAllText("OUTPUT.txt", dist.ToString());
                    return;
                }

                // Try moving forward
                int nx = x + dx[dir];
                int ny = y + dy[dir];
                if (IsValid(nx, ny, N, M, maze) && !visited[nx, ny, dir, rightTurns])
                {
                    visited[nx, ny, dir, rightTurns] = true;
                    queue.Enqueue((nx, ny, dir, rightTurns, dist + 1));
                }

                // Try turning right
                int newDir = (dir + 1) % 4;
                if (rightTurns < K)
                {
                    nx = x + dx[newDir];
                    ny = y + dy[newDir];
                    if (IsValid(nx, ny, N, M, maze) && !visited[nx, ny, newDir, rightTurns + 1])
                    {
                        visited[nx, ny, newDir, rightTurns + 1] = true;
                        queue.Enqueue((nx, ny, newDir, rightTurns + 1, dist + 1));
                    }
                }

                // Try turning left
                newDir = (dir + 3) % 4;
                nx = x + dx[newDir];
                ny = y + dy[newDir];
                if (IsValid(nx, ny, N, M, maze) && !visited[nx, ny, newDir, rightTurns])
                {
                    visited[nx, ny, newDir, rightTurns] = true;
                    queue.Enqueue((nx, ny, newDir, rightTurns, dist + 1));
                }
            }

            File.WriteAllText("OUTPUT.txt", "-1");
        }
        static bool IsValid(int x, int y, int N, int M, int[,] maze)
        {
            return x >= 0 && x < N && y >= 0 && y < M && maze[x, y] != 1;
        }
    }
}
