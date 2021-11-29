using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_3_3
{
    static class CMonitor
    {
        public static List<List<int>> HashList = new List<List<int>>();

        public static List<Mutex> mutices = new List<Mutex>();

        public static void InitializeRowsOfHashTable(int n)
        {
            for (int i = 0; i < n; i++)
            {
                HashList.Add(new List<int>());
            }
            InitializeMutices(n);
        }

        static void InitializeMutices(int n)
        {
            for (int i = 0; i < n; i++)
            {
                mutices.Add(new Mutex(false, Convert.ToString(n)));
            }
        }

        public static void AddToHashTable(int i, int value)
        {
            HashList[i].Add(value);
        }

        public static void Output()
        {
            for (int i = 0; i < HashList.Count; i++)
            {
                for (int j = 0; j < HashList[i].Count; j++)
                {
                    Console.Write(String.Format("{0, 6}", HashList[i][j]));
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        public static int k = 0;

        public static int GetHash(int x) => x % k;

        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            Console.WriteLine("Введите количество элементов:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите основание хэш-функции (кроме 0):");
            k = int.Parse(Console.ReadLine());

            CMonitor.InitializeRowsOfHashTable(k);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < n; i++)
            {         
                threads.Add(new Thread(() => 
                { 
                    int f = random.Next(0, 333);
                    int pos = GetHash(f);

                    CMonitor.mutices[pos].WaitOne();
                    try
                    {
                        CMonitor.AddToHashTable(pos, f);
                    }
                    finally
                    {
                        CMonitor.mutices[pos].ReleaseMutex();
                    }
                }));
            }

            foreach (Thread a in threads) a.Start();

            CMonitor.Output();
        }
    }
}
