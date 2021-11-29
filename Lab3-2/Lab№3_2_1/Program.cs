using System;
using System.Threading;
using System.IO;

namespace Lab_3_2_1
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "Mutex");
        static void StringToTxtFile(string inputline)
        {           
            mutex.WaitOne();
            Console.WriteLine("Inserting...");
            Thread.Sleep(6000);
            string path = "text.txt";
            File.WriteAllText(path, inputline);
            Console.WriteLine("Done.");
            mutex.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Console.Write("Input text: ");
            string inputline = Console.ReadLine();
            Thread thread = new Thread(() => { StringToTxtFile(inputline); });
            thread.Start();
            Console.ReadKey();
        }
    }
}
