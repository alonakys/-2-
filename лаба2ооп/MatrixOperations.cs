using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix matr1, MyMatrix matr2)
        {
            if (matr1.Width != matr2.Width || matr1.Height != matr2.Height)
            {
                throw new InvalidOperationException("Матрицi мають рiзнi розмiри");
            }
            double[,] array = new double[matr1.Height, matr2.Width];
            for (int i = 0; i < matr1.Height; i++)
            {
                for (int j = 0; j < matr2.Width; j++)
                {
                    array[i, j] = matr1[i, j] + matr2[i, j];
                }
            }
            return new MyMatrix(array);
        }
        public static MyMatrix operator *(MyMatrix matr1, MyMatrix matr2)
        {
            if (matr1.Width != matr2.Height)
            {
                throw new InvalidOperationException("Розмiри матриць не задовольняють умов множення матриць");
            }
            double[,] array = new double[matr1.Height, matr2.Width];
            for (int c = 0; c < matr2.Width; c++)
            {
                for (int i = 0; i < matr1.Height; i++)
                {
                    for (int j = 0; j < matr1.Width; j++)
                    {
                        array[i, c] += matr1[i, j] * matr2[j, c];
                    }
                }
            }
            return new MyMatrix(array);
        }
        protected double[,] GetTransponedArray()
        {
            double[,] arr = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    arr[i, j] = matrix[j, i];
                }
            }
            return arr;
        }
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(this.GetTransponedArray());
        }
        public void TransponeMe()
        {
            MyMatrix matr = new MyMatrix(this.GetTransponedArray());
            this.matrix = new double[matr.Width, matr.Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    matrix[i, j] = matr[i, j];
                }
            }
        }
    }
}
