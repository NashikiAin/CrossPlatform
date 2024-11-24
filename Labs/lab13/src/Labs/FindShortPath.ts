export class FindShortPath {
    static find(
      maze: number[][],
      N: number,
      M: number,
      K: number,
      startX: number,
      startY: number,
      endX: number,
      endY: number
    ): number {
      const dx = [-1, 0, 1, 0];
      const dy = [0, 1, 0, -1];
      const queue: Array<[number, number, number, number, number]> = [];
      const visited = new Array(N)
        .fill(null)
        .map(() =>
          new Array(M)
            .fill(null)
            .map(() => new Array(4).fill(null).map(() => new Array(K + 1).fill(false)))
        );
  
      for (let d = 0; d < 4; d++) {
        queue.push([startX, startY, d, 0, 0]);
        visited[startX][startY][d][0] = true;
      }
  
      while (queue.length > 0) {
        const [x, y, dir, rightTurns, dist] = queue.shift()!;
  
        if (x === endX && y === endY) {
          return dist; // Return the distance when destination is reached
        }
  
        // Try moving forward
        let nx = x + dx[dir];
        let ny = y + dy[dir];
        if (this.isValid(nx, ny, N, M, maze) && !visited[nx][ny][dir][rightTurns]) {
          visited[nx][ny][dir][rightTurns] = true;
          queue.push([nx, ny, dir, rightTurns, dist + 1]);
        }
  
        // Try turning right
        let newDir = (dir + 1) % 4;
        if (rightTurns < K) {
          nx = x + dx[newDir];
          ny = y + dy[newDir];
          if (this.isValid(nx, ny, N, M, maze) && !visited[nx][ny][newDir][rightTurns + 1]) {
            visited[nx][ny][newDir][rightTurns + 1] = true;
            queue.push([nx, ny, newDir, rightTurns + 1, dist + 1]);
          }
        }
  
        // Try turning left
        newDir = (dir + 3) % 4;
        nx = x + dx[newDir];
        ny = y + dy[newDir];
        if (this.isValid(nx, ny, N, M, maze) && !visited[nx][ny][newDir][rightTurns]) {
          visited[nx][ny][newDir][rightTurns] = true;
          queue.push([nx, ny, newDir, rightTurns, dist + 1]);
        }
      }
  
      return -1; // If no path is found
    }
  
    static isValid(x: number, y: number, N: number, M: number, maze: number[][]): boolean {
      return x >= 0 && x < N && y >= 0 && y < M && maze[x][y] !== 1;
    }
  }
  