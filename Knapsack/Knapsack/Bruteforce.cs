using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Tovar
    {
        public int Weight { get; set; }
        public int Value { get; set; }
    }
    class Bruteforce
    {
        int capacity;
        int[] weight;
        int[] value;
        int itemscount;
        List<List<Tovar>> permutList = new List<List<Tovar>>();
        List<Tovar> path = new List<Tovar>();
        List<Tovar> tovars = new List<Tovar>();

        public Bruteforce(int capacity, int[] weight, int[] value, int itemsCount)
        {
            this.capacity = capacity;
            this.weight = weight;
            this.value = value;
            this.itemscount = itemsCount;
        }

        private List<List<Tovar>> PowerSet(List<Tovar> tovars)
        {
            int n = tovars.Count;
            // Power set contains 2^N subsets.
            int powerSetCount = 1 << n;
            var ans = new List<List<Tovar>>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                var s = new List<Tovar>();
                for (int i = 0; i < n; i++)
                {
                    // Checking whether i'th element of input collection should go to the current subset.
                    if ((setMask & (1 << i)) > 0)
                    {
                        s.Add(tovars[i]);
                    }
                }
                ans.Add(s);
            }

            return ans;
        }

        private long KnapSack(int capacity)
        {

            long bestvalue = 0;
            long result = 0;
            permutList = PowerSet(tovars);
            
            foreach(List<Tovar> a in permutList)
            {
                long weight_of_permutation = 0;
                foreach(Tovar b in a)
                {
                    weight_of_permutation += b.Weight;
                }
                if (weight_of_permutation < capacity)
                {
                    foreach (Tovar b in a)
                    {
                        bestvalue += b.Value;
                    }
                    if (bestvalue > result)
                    {
                        result = bestvalue;                      
                    }
                    bestvalue = 0;
                }
            }
            return result;
        }

        public void Start()
        {
            for (int i = 0; i < weight.Length; i++)
            {
                tovars.Add(new Tovar { Weight = weight[i], Value = value[i] });
            }
            Console.Write(KnapSack(this.capacity));
        }
    }
}
