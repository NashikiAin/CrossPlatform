using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
	public static class Utils
	{
		public static void Permute(int[] arr, int index, int K, ref int count)
		{
			if (index == arr.Length - 1)
			{
				bool isValid = true;
				for (int i = 0; i < arr.Length - 1; i++)
				{
					if (Math.Abs(arr[i] - arr[i + 1]) > K)
					{
						isValid = false;
						break;
					}
				}

				if (isValid)
					count++;
			}
			else
			{
				for (int i = index; i < arr.Length; i++)
				{
					Swap(ref arr[index], ref arr[i]);
					Permute(arr, index + 1, K, ref count);
					Swap(ref arr[index], ref arr[i]);
				}
			}
		}

		static void Swap(ref int a, ref int b)
		{
			int tmp = a;
			a = b;
			b = tmp;
		}
	}
}
