using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Laba_1
{
    class Sorting
    {
        public static void RowSortingThreadMaker(int[][] matrix)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < matrix.Length; i++)
            {
                object a = i;
                threads.Add(new Thread(() => { RowSort(matrix[(int)a]); }));
            }
            MatrixInit.ThreadStarter(threads);
        }

        public static int[] RowSort(int[] array)
        {
            {
                var min = array.Min();
                var max = array.Max();

                var correctionFactor = min != 0 ? -min : 0;
                max += correctionFactor;

                var count = new int[max + 1];
                for (var i = 0; i < array.Length; i++)
                {
                    count[array[i] + correctionFactor]++;
                }

                var index = 0;
                for (var i = 0; i < count.Length; i++)
                {
                    for (var j = 0; j < count[i]; j++)
                    {
                        array[index] = i - correctionFactor;
                        index++;
                    }
                }
            }
            return array;
        }
    }
}