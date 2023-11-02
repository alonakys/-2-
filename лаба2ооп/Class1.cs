using System;
using System.Collections.Generic;
using System.Text;

namespace лаба2ооп
{
    public partial class MyMatrix
    {
        private double[,] matrix;

        public MyMatrix(MyMatrix other)
        {
            this.matrix = (double[,])other.matrix.Clone();
        }

        public MyMatrix(double[,] data)
        {
            this.matrix = (double[,])data.Clone();
        }

        public MyMatrix(double[][] data)
        {
            int numRows = data.Length;
            int numCols = data[0].Length;

            for (int i = 1; i < numRows; i++)
            {
                if (data[i].Length != numCols)
                {
                    throw new ArgumentException("Зубчастий масив не є прямокутною матрицею");
                }
            }

            matrix = new double[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = data[i][j];
                }
            }
        }

        public MyMatrix(string[] data)
        {
            int numRows = data.Length;
            int numCols = data[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[numRows, numCols];
            for (int i = 1; i < numRows; i++)
            {
                var rowData = Array.ConvertAll(data[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), double.Parse);
                if (rowData.Length != numCols)
                {
                    throw new ArgumentException("рiзна кiлькiсть чисел у рядку");
                }
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }
        }

        public int Height //properties
        {
            get { return matrix.GetLength(0); }
        }

        public int Width
        {
            get { return matrix.GetLength(1); }
        }
        public int getHeight() //java-style
        { return Height; }
        public int getWeight()
        { return Width; }

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set 
            { 
                matrix[row, col] = value;
                dererminant = null;
            }
        }
        public double getElem(int row, int col)
        { return matrix[row, col]; }
        public void setElem(int row, int col, double value)
        { 
            matrix[row, col] = value;
            dererminant = null;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += matrix[i, j].ToString() + " ";
                    if (j < Width - 1)
                    {
                        result += " ";
                    }
                }
                if (i < Height - 1)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }
    }
}
