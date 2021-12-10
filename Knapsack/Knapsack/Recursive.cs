using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Recursive
    {
        int capacity;
        int[] weight;
        int[] value;
        int itemscount;

        public Recursive(int capacity, int[] weight, int[] value, int itemsCount)
        {
            this.capacity = capacity;
            this.weight = weight;
            this.value = value;
            this.itemscount = itemsCount;
        }

        private int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        private int KnapSack(int W, int[] wt, int[] val, int n)
        {

            if (n == 0 || W == 0)
                return 0;


            if (wt[n - 1] > W)
                return KnapSack(W, wt,
                                val, n - 1);

            else
                return max(val[n - 1] + KnapSack(W - wt[n - 1], wt, val, n - 1), KnapSack(W, wt, val, n - 1));
        }


        public void Start()
        {
            Console.WriteLine(KnapSack(this.capacity, this.weight, this.value, this.itemscount));
        }
    }
}
