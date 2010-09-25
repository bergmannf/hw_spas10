using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_One
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix();
            int[,] matrixOne = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrixTwo = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] result = m.MultiplyMatrices(matrixOne, matrixTwo);
            Console.WriteLine("Result is: {0}", m.PrintMatrix(result));
            Console.ReadLine();
        }
    }
}
