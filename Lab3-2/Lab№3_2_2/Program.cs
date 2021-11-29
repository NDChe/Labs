using System;
using System.IO;
using System.Threading;

namespace Lab_3_2_2
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "Mutex");

        static void ReadFromTxtFile()
        {
            Console.WriteLine("Waiting for Mutex...");
            mutex.WaitOne();
            Console.WriteLine("Reading...");
            string path = @"C:\Users\N\Desktop\ЗОС_Лабы_7трим\Lab№3_2_1\Lab№3_2_1\bin\Debug\netcoreapp3.1\text.txt";
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("Done.");
            mutex.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
            Thread thread = new Thread(() => { ReadFromTxtFile(); });
            thread.Start();
            Console.ReadKey();
        }
    }
}
