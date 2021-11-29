using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Laba_1
{
    class Multiply
    {
        public static void RowMultThreadMaker(int[][] matrix, int X)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < matrix.Length; i++)
            {
                object a = i;
                threads.Add(new Thread(() => { RowMultiply(matrix[(int)a], X); }));
            }
            MatrixInit.ThreadStarter(threads);
        }

        private static void RowMultiply(int[] vs, int x)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] *= x;
            }
        }
    }
}
