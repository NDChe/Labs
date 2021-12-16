using System;
using System.Diagnostics;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод: Вручную (0), Автоматически (1)");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        Console.WriteLine("Введите кол-во предметов (n): ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите вместимость рюкзака (m): ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        int [] weight = new int[n];
                        int [] value = new int[n]; 
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Введите вес предмета #" + i);
                            weight[i] = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите стоимость предмета #" + i);
                            value[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Выберите метод: (0) - Перебор; (1) - Жадный алгоритм; (2) - Динамический алгоритм");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 0:
                                {
                                    Bruteforce func = new Bruteforce(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time / 10000 + "ms");
                                    break;
                                }
                            case 1:
                                {
                                    Greedy func = new Greedy(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time / 10000 + "ms");
                                    break;
                                }
                            case 2:
                                {
                                    Dynamic func = new Dynamic(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time / 10000 + "ms");
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        Random random = new Random(DateTime.Now.Millisecond);
                        int n = 50;// random.Next(3, 100);   //Количество предметов
                        int m = 5;// random.Next(3, 100);    //Вместимость рюкзака
                        int[] weight = new int[n];
                        int[] value = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            weight[i] = random.Next(3, 100); 
                            value[i] = random.Next(3, 100);
                        }
                        Console.WriteLine("Выберите метод: (0) - Перебор; (1) - Жадный алгоритм; (2) - Динамический алгоритм");
                        choice = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Вместимость: " + m + "\nКоличество: " + n);


                        switch (choice)
                        {
                            case 0:
                                {
                                    Bruteforce func = new Bruteforce(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time / 10000 + "ms");
                                    break;
                                }
                            case 1:
                                {                                 
                                    Greedy func = new Greedy(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time / 10000 + "ms");
                                    break;
                                }
                            case 2:
                                {
                                    Dynamic func = new Dynamic(m, weight, value, n);
                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    Console.Write("Результат: ");
                                    func.Start();
                                    stopwatch.Stop();
                                    long time = stopwatch.ElapsedTicks;
                                    Console.WriteLine("\nПрошло времени: " + time/10000 + "ms");
                                    break;
                                }
                        }
                        break;
                    }
            }

        }
    }
}
