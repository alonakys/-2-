using System;

namespace лаба2ооп
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix m1 = new MyMatrix(new double[,] { { 5, 8, -4 }, { 6, 9, -5 }, { 4, 7, -3 } });
            MyMatrix m2 = new MyMatrix(new double[,] { { 3, 2, 5 }, { 4, -1, 3 }, { 9, 6, 5 } });
            Console.WriteLine(m1);
            Console.WriteLine();
            Console.WriteLine(m2);
            Console.WriteLine();
            Console.WriteLine(m1+m2);
            Console.WriteLine();
            Console.WriteLine(m1*m2);
        }
    }
}
