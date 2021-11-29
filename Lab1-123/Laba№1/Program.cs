using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace Laba_1
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания");
            string f = Console.ReadLine();
            switch (f)
            {
                case "1":
                    {
                        /*         Задание 1 - Инициализация           */
                        int ROWS; int COLUMNS;
                        Console.WriteLine("Введите кол-во строк и кол-во стобцов: ");
                        ROWS = Int32.Parse(Console.ReadLine()); COLUMNS = Int32.Parse(Console.ReadLine());

                        float[][] Matrix = new float[ROWS][];
                        int[] IndexArray = new int[Matrix.Length];
                        for (int i = 0; i < IndexArray.Length; i++)
                        {
                            IndexArray[i] = i;
                        }

                        MatrixInit.ColumnsInitThreadMaker(COLUMNS, Matrix, IndexArray);
                        Thread.Sleep(100);
                        MatrixInit.MatrixPrinter(Matrix);
                        /*         Задание 0 - Суммирование           */

                        float[] Sum = new float[Matrix.Length];


                        MatrixSumm.ColumnSumThreadMaker(Matrix, Sum);
                        MatrixInit.ArrayPrinter(Sum);

                        break;
                    }                        
                case "2":
                    {
                        /*     Задание 2 - Сортировка подсчётом       */
                        int ROWS; int COLUMNS;
                        Console.WriteLine("Введите кол-во строк и кол-во стобцов: ");
                        ROWS = Int32.Parse(Console.ReadLine()); COLUMNS = Int32.Parse(Console.ReadLine());

                        int[][] Matrix = new int[ROWS][];
                        int[] IndexArray = new int[Matrix.Length];
                        for (int i = 0; i < IndexArray.Length; i++)
                        {
                            IndexArray[i] = i;
                        }

                        MatrixInit.ColumnsInitThreadMaker(COLUMNS, Matrix, IndexArray);
                        Thread.Sleep(100);
                        MatrixInit.MatrixPrinter(Matrix);
                        Sorting.RowSortingThreadMaker(Matrix);
                        Thread.Sleep(100);
                        MatrixInit.MatrixPrinter(Matrix);
                        break;
                    }
                case "3":
                    {
                        /*     Задание 3 - Умножение матрицы       */
                        int ROWS; int COLUMNS;
                        Console.WriteLine("Введите кол-во строк и кол-во стобцов: ");
                        ROWS = Int32.Parse(Console.ReadLine()); COLUMNS = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите множитель: ");
                        int X = Int32.Parse(Console.ReadLine());

                        int[][] Matrix = new int[ROWS][];
                        int[] IndexArray = new int[Matrix.Length];
                        for (int i = 0; i < IndexArray.Length; i++)
                        {
                            IndexArray[i] = i;
                        }

                        MatrixInit.ColumnsInitThreadMaker(COLUMNS, Matrix, IndexArray);
                        Thread.Sleep(100);
                        MatrixInit.MatrixPrinter(Matrix);
                        Multiply.RowMultThreadMaker(Matrix, X);
                        Thread.Sleep(100);
                        MatrixInit.MatrixPrinter(Matrix);

                        break;
                    }
            }
        }
    }
}
