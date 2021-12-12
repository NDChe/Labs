using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Bruteforce
    {
		int capacity;
		int[] weight;
		int[] value;
		int itemscount;

		public Bruteforce(int capacity, int[] weight, int[] value, int itemsCount)
        {
			this.capacity = capacity;
			this.weight = weight;
			this.value = value;
			this.itemscount = itemsCount;
        }

		public void Start() //Это алгоритм
		{
			int[,] K = new int[itemscount + 1, capacity + 1];

			for (int i = 0; i <= itemscount; ++i)
			{
				for (int w = 0; w <= capacity; ++w)
				{
					if (i == 0 || w == 0)
						K[i, w] = 0;
					else if (weight[i - 1] <= w)
						K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
					else
						K[i, w] = K[i - 1, w];
				}
			}

			Console.Write(K[itemscount, capacity]);
		}
	}
}
