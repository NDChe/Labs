using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab_2
{
    class Program
    {
        static float sum = 0;
        static object locker = new object();
        public static Random random = new Random(DateTime.Now.Millisecond);

        static void InitRow(float[][] vs, int size, int i)
        {
            vs[i] = new float[size];
            for (int j = 0; j < size; j++)
            {
                vs[i][j] = (float)(Math.Round(random.NextDouble(), 3));
            }
        }

        static void SumRow(float[][] vs, int i)
        {
            Thread.Sleep(75);
            lock (locker)
            {
                for (int j = 0; j < vs[i].Length; j++)
                {
                    sum += vs[i][j];
                }
            }
        }

        static void ThreadStart(List<Thread> threads)
        {
            foreach(Thread a in threads)
            {
                a.Start();
            }
        }

        static void Pritner(float[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write("{0, 6:N3}", matrix[i][j]);
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());
            float[][] Matrix = new float[m][];

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < Matrix.Length; i++)
            {
                object o = i;                
                threads.Add(new Thread(() => { InitRow(Matrix, n, (int)o); }));
                threads.Add(new Thread(() => { SumRow(Matrix, (int)o); }));
            }
            ThreadStart(threads);

            Thread.Sleep(100);

            Pritner(Matrix);
            Console.WriteLine(sum);
        }
    }
}
