export class CalcPrefSum {
    static calculateRemainingCoins(coins: number[], N: number): number[] {
      const sum = new Array(N + 1).fill(0);
      for (let i = N - 1; i >= 0; i--) {
        sum[i] = sum[i + 1] + coins[i]; 
      }
      return sum;
    }
  }
  