using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Laba_1
{
    class MatrixSumm
    {
        public static void ColumnSumThreadMaker(float[][] matrix, float[] sum)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < matrix.Length; i++)
            {               
                object a = i;
                threads.Add(new Thread(() => { ColumnSummator(matrix, (int)a, ref sum[(int)a]);}));
            }
            MatrixInit.ThreadStarter(threads);
        }

        static void ColumnSummator(float[][] matrix, int RowNumber, ref float sum)
        {
            for (int i = 0; i < matrix[RowNumber].Length; i++)
            {
                sum += matrix[i][RowNumber];
            }
        }
    }
}
