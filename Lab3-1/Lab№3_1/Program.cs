using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_3_1
{
    class Program
    {
        public static Mutex mutex = new Mutex();
        public static double result = 0;

        static void MultiplyAndAdd(int a, int b)
        {
            if (mutex.WaitOne())
            {
                try
                {
                    result += a * b;
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }      
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            Console.WriteLine("Введите первый вектор:");
            object x = Convert.ToInt32(Console.ReadLine());
            object y = Convert.ToInt32(Console.ReadLine());
            object z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество векторов, которые хотите присуммировать");
            int n = 0;
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите их");
            for (int i = 1; i < n; i++)
            {
                object X = Convert.ToInt32(Console.ReadLine());
                threads.Add(new Thread(() => { MultiplyAndAdd((int)x, (int)X); }));
                object Y = Convert.ToInt32(Console.ReadLine());
                threads.Add(new Thread(() => { MultiplyAndAdd((int)y, (int)Y); }));
                object Z = Convert.ToInt32(Console.ReadLine());
                threads.Add(new Thread(() => { MultiplyAndAdd((int)z, (int)Z); }));
                Console.WriteLine("Добавлен");
            }
            foreach (Thread a in threads) a.Start();

            Thread.Sleep(100);
            Console.WriteLine(result);

        }
    }
}
