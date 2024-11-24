// CalcMaxCoins.ts
export class CalcMaxCoins {
    // Function to calculate the maximum number of coins for the first player
    static calculateMaxCoins(coins: number[], sum: number[], N: number, K: number): number {
      const dp: number[][] = Array.from({ length: N + 1 }, () => new Array(K + 1).fill(0));
  
      for (let i = N - 1; i >= 0; i--) {
        for (let x = 1; x <= K; x++) {
          for (let take = 1; take <= x && i + take <= N; take++) {
            dp[i][x] = Math.max(dp[i][x], sum[i] - dp[i + take][Math.min(K, take)]);
          }
        }
      }
  
      return dp[0][K];
    }
  }
  