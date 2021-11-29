using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab2_2
{
    class Program
    {
        public static Random random = new Random();
        public static byte sum = 0;
        public static object locker = new object();

        public static void Sum256(ref byte[] array, int k, int i)
        {
            for (int s = 0; i + k * s < array.Length; s++)
            {
                lock (locker)
                {
                    sum += array[i + k * s];
                }
            }
        }

        public static void Start(List<Thread> threads)
        {
            foreach(Thread a in threads)
            {
                a.Start();
            }
        }

        static void Main(string[] args)
        {  
            string str = "ABCD";
            byte[] data = Encoding.ASCII.GetBytes(str);
            int k = random.Next(1, data.Length - 1);
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < k; i++)
            {
                object o = i;
                threads.Add(new Thread(() => { Sum256(ref data, k, (int)o); }));
            }
            Start(threads);
            Thread.Sleep(100);
            Console.WriteLine(sum);
        }
    }
}
