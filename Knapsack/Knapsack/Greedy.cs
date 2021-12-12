using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Tovar
    {
        public int first;
        public int second;
    }

    class Greedy
    {
        int capacity;
        int[] weight;
        int[] value;
        int itemscount;

        public Greedy(int capacity, int[] weight, int[] value, int itemsCount)
        {
            this.capacity = capacity;
            this.weight = weight;
            this.value = value;
            this.itemscount = itemsCount;
        }

        public void Start()
        {
            List<Tovar> tovars = new List<Tovar>();

            for(int i = 0; i < this.weight.Length; i++)
            {
                Tovar tovar = new Tovar { first = this.weight[i], second = this.value[i] };
                tovars.Add(tovar);
            }

            Console.Write(KnapSack(tovars, this.capacity));
        }

        static void Swap<T>(ref T arg1, ref T arg2) where T : struct
        {
            T temp = arg1;
            arg1 = arg2;
            arg2 = temp;
        }

        static double KnapSack(List<Tovar> vec, int W)
        {
            List<double> chena = new List<double>();
            double c = 0, k;
            for (int j = 0; j < vec.Count(); j++)
            {
                chena.Add(vec[j].first / vec[j].second);
            }
            for (int i = 0; i < chena.Count(); i++)
            {
                for (int j = i + 1; j < chena.Count(); j++)
                    if (chena[i] < chena[j])
                    {
                        var a = chena[i];
                        chena[i] = chena[j];
                        chena[j] = a;
                        var b = vec[i];
                        vec[i] = vec[j];
                        vec[j] = b;
                    }
            }
            while (W > 0)
            {
                for (int i = 0; i < chena.Count(); i++)
                {

                    if ((W - vec[i].second) >= 0)
                        k = 1;
                    else k = -((W - vec[i].second) / vec[i].second);
                    W -= ((int)Math.Abs(k) * vec[i].second);
                    if (W < 0) break;
                    c += (vec[i].first * k);
                }
            }
            return c;
        }
    }
}
