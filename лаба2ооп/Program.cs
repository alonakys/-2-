using System;

namespace лаба2ооп
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix m1 = new MyMatrix(new double[,] { { 5, 8, -4 }, { 6, 9, -5 }, { 4, 7, -3 } });
            MyMatrix m2 = new MyMatrix(new double[,] { { 3, 2, 5 }, { 4, -1, 3 }, { 9, 6, 5 } });
            MyMatrix m3 = new MyMatrix(new string[] { "0 0  0", "5  7 3", "2 6 6" });
            MyMatrix m4 = new MyMatrix("4 5     6\n5 6 7\n46 7 8");
            Console.WriteLine(m1);
            Console.WriteLine();
            Console.WriteLine(m2);
            Console.WriteLine();
            Console.WriteLine(m4);
            Console.WriteLine();
            Console.WriteLine(m1+m2);
            Console.WriteLine();
            Console.WriteLine(m1*m2);
        }
    }
}
