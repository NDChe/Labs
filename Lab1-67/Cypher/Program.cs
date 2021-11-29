using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cypher
{
    class Program
    {
        protected static char[][] SplitString(string Text, int size)
        {
            int k = 0;
            char[][] Chars = new char[Text.Length / size + 1][];
            for(int i = 0; i < Text.Length/size + 1; i++)
            {
                Chars[i] = new char[size];
                for (int j = 0; j < size; j++)
                {
                    if (k < Text.Length)
                    {
                        Chars[i][j] = Text[k];
                        k++;
                    }
                    else Chars[i][j] = ' ';
                }
            }
            return Chars;
        }

        static void Swap(ref char a, ref char b)
        {
            char c = a;
            a = b;
            b = c;
        }

        protected static void ReverseArray(char[] array)
        {
            for (int i = 0; i < array.Length/2; i++)
            {
                Swap(ref array[i], ref array[array.Length - i - 1]);
            }
        }

        public static void PrintArray(char[][] Chars)
        {
            for (int i = 0; i < Chars.Length; i++)
            {
                for (int j = 0; j < Chars[i].Length; j++)
                {
                    Console.Write(Chars[i][j]);
                }
            }
            Console.WriteLine();
        }

        public static void ApplyKey(ref char[] Chars, ref char[] Key)
        {
            for (int i = 0; i < Chars.Length; i++)
            {
                int v = Chars[i] ^ Key[i];
                Chars[i] = (char)v;
            }
        }

        public static void ReverseText(char[][] Chars)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Chars.Length; i++)
            {
                object o = i;
                threads.Add(new Thread(() => { ReverseArray(Chars[(int)o]); }));
            }
            foreach (Thread a in threads) a.Start();
        }

        public static void ApplyKeyToText(char[][] Chars, char[] Key)
        {
            List <Thread> threads = new List<Thread>();
            for (int i = 0; i < Chars.Length; i++)
            {
                object o = i;
                threads.Add(new Thread(() => { ApplyKey(ref Chars[(int)o], ref Key); }));               
            }
            foreach (Thread a in threads) a.Start();
        }

        static void Main(string[] args)
        {
            Console.Write("Input text: ");
            string OriginalText = "Crazy Fredrick bought many very exquisite opal jewels. ";
            OriginalText = Console.ReadLine();
            Console.Write("Input key: ");
            string StrKey = Console.ReadLine();
            char[] Key = { '0', '0' , '0' , '0' , '0' , '0' , '0' , '0' };
            if (StrKey.Length > 0) Key = StrKey.ToCharArray();

            char[][] Chars = SplitString(OriginalText, Key.Length);

            PrintArray(Chars); //

            ReverseText(Chars);
       
            PrintArray(Chars); //

            ApplyKeyToText(Chars, Key);

            PrintArray(Chars); //

            ApplyKeyToText(Chars, Key);

            Thread.Sleep(100);

            PrintArray(Chars); //

            ReverseText(Chars);

            PrintArray(Chars); //
        }
    }
}
