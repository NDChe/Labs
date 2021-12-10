using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;


namespace Lab4_1
{
    class Pool
    {
        List<Char> P = new List<char>();

        public StreamReader streamReader1;
        public StreamReader streamReader2;

        object locker = new object();

        Mutex WriterIsReadyToWrite;
        Semaphore ReaderIsReadyToRead = new Semaphore(2, 2);

        StreamWriter streamWriter = new StreamWriter("output.txt");

        const int MaxPoolCapacity = 8;
        byte ThreadsFinished = 0;


        public Pool(string path1, string path2)
        {
            streamReader1 = new StreamReader(path1);
            streamReader2 = new StreamReader(path2);
        }

        public void Ignition()
        {
            Thread Reader1 = new Thread(() => Reader(streamReader1));
            Thread Reader2 = new Thread(() => Reader(streamReader2));
            Thread writer = new Thread(() => Writer());
            
            
            writer.Start();
            Thread.Sleep(50);
            Reader1.Start(); Reader2.Start();
        }

        public void Reader(StreamReader streamReader)
        {
            ReaderIsReadyToRead.WaitOne();
            lock (locker)
            {
                while ((!streamReader.EndOfStream))
                {
                    WriterIsReadyToWrite.WaitOne();
                    P.Add((char)streamReader.Read());
                    if (streamReader.EndOfStream) ThreadsFinished++;
                    WriterIsReadyToWrite.ReleaseMutex();
                }
            }
            ReaderIsReadyToRead.Release();
        }

        public void Writer()
        {
            WriterIsReadyToWrite = new Mutex();

            while (ThreadsFinished < 2)
            {
                for (int i = 0; i < MaxPoolCapacity; i++)
                {
                    if (P.Count > 0)
                    {
                        WriterIsReadyToWrite.WaitOne();
                        if ((P.Count >= MaxPoolCapacity) || (ThreadsFinished >= 2))
                        {
                            streamWriter.Write(P[0]);
                            P.RemoveAt(0);
                        }
                        WriterIsReadyToWrite.ReleaseMutex();
                    }
                }
            }
            streamWriter.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "input1.txt";
            string path2 = "input2.txt";
            Pool Pool = new Pool(path1, path2);
            Pool.Ignition();
        }
    }
}
