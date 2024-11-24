export class Utils {
    static permute(arr: number[], index: number, K: number, count: { value: number }): void {
      if (index === arr.length - 1) {
        let isValid = true;
  
        for (let i = 0; i < arr.length - 1; i++) {
          if (Math.abs(arr[i] - arr[i + 1]) > K) {
            isValid = false;
            break;
          }
        }
  
        if (isValid) {
          count.value++;
        }
      } else {
        for (let i = index; i < arr.length; i++) {
          Utils.swap(arr, index, i);
          Utils.permute(arr, index + 1, K, count);
          Utils.swap(arr, index, i);
        }
      }
    }
  
    private static swap(arr: number[], a: number, b: number): void {
      const temp = arr[a];
      arr[a] = arr[b];
      arr[b] = temp;
    }
  }
  