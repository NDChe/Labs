using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab2_3
{
    class Program
    {
        public static Random random = new Random();
        public static double Function(double x)=>  x * (x - 1);
        public static double Sum = 0;
        public static object locker = new object();
        public static void Rectangle(double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i <= n - 1; i++)
            {
                var x = a + i * h;
                sum += Function(x);
            }

            var result = h * sum;
            lock(locker)
            {
                Sum += result;
            }
        }

        public static void Starter(List<Thread> threads)
        {
            foreach(Thread a in threads)
            {
                a.Start();
            }
        }

        static void Main(string[] args)
        {
            double a = 0;
            double b = 2;
            int n = 50;
            int m = 50;
            double size = (b - a) / n;
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < n; i++)
            {
                double start = i * size;
                double end = (i + 1) * size;
                threads.Add(new Thread(() => { Rectangle(start, end, m); }));
            }
            Starter(threads);
            Thread.Sleep(100);
            Console.WriteLine(Sum);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(n);
            Console.WriteLine(m);
        }
    }
}
