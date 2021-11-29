using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Laba_1
{
    public class MatrixInit
    {
        public static Random random = new Random();

        static void ColumnsInitiator(float[][] matrix, int RowNumber, int ColumnAmount)
        {
            matrix[RowNumber] = new float[ColumnAmount];
            ColumnFiller(matrix, RowNumber);
        }

        static void ColumnsInitiator(int[][] matrix, int RowNumber, int ColumnAmount)
        {
            matrix[RowNumber] = new int[ColumnAmount];
            ColumnFiller(matrix, RowNumber);
        }

        static void ColumnFiller(float[][] matrix, int RowNumber)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[RowNumber][i] = (float)Math.Round((double)random.NextDouble() * 10, 3);
            }
        }

        static void ColumnFiller(int[][] matrix, int RowNumber)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[RowNumber][i] = random.Next(0, 30);
            }
        }

        
        public static void ColumnsInitThreadMaker(int IWishThereWasAmountOfCoulumns, float[][] matrix, int[] IndexArray)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < matrix.Length; i++)
            {
                object a = i;
                threads.Add(new Thread(() => { ColumnsInitiator(matrix, (int)a, IWishThereWasAmountOfCoulumns); }));
            }
            ThreadStarter(threads);
        }

        public static void ColumnsInitThreadMaker(int IWishThereWasAmountOfCoulumns, int[][] matrix, int[] IndexArray)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < matrix.Length; i++)
            {
                object a = i;
                threads.Add(new Thread(() => { ColumnsInitiator(matrix, (int)a, IWishThereWasAmountOfCoulumns); }));
            }
            ThreadStarter(threads);
        }

        public static void ThreadStarter(List<Thread> threads)
        {
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
        }

        public static void MatrixPrinter(float[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.Write("{0, 6:N3}", matrix[i][j]);
                }
                Console.Write("\n");
            }
        }

        public static void MatrixPrinter(int[][] matrix)
        {
            Console.Write("\n");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.Write("{0, 6}", matrix[i][j]);
                }
                Console.Write("\n");
            }
        }

        public static void ArrayPrinter(float[] matrix)
        {
            Console.Write("\n");
            for (int i = 0; i < matrix.Length; i++)
            {
                    Console.Write("{0, 10:N3}", matrix[i]);
            }
        }

    }
}
