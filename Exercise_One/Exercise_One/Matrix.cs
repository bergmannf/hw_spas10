using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_One
{
    class Matrix
    {

        public int[,] MultiplyMatrices(int[,] matrixOne, int[,] matrixTwo)
        {
            int rowsMatrixOne = matrixOne.GetLength((int) MatrixDimensions.DIMENSION_TWO);
            int columnsMatrixTwo = matrixTwo.GetLength((int) MatrixDimensions.DIMENSION_ONE);
            int rowsMatrixTwo = matrixTwo.GetLength((int)MatrixDimensions.DIMENSION_TWO);
            int[,] resultMatrix = new int[rowsMatrixTwo, rowsMatrixOne];
            
            if (rowsMatrixOne != columnsMatrixTwo)
            {
                throw new ArgumentException("Provided matrices don't match: number of columns of matrix one need to match rows of matrix two.");
            }
            int cellValue = 0;

            for (int i = 0; i < rowsMatrixOne; i++)
            {
                for (int k = 0; k < rowsMatrixTwo; k++)
                {
                    for (int j = 0; j < columnsMatrixTwo; j++)
                    {
                        cellValue += matrixOne[i, j] * matrixTwo[j, k];
                    }
                    resultMatrix[k, i] = cellValue;
                    cellValue = 0;
                } 
            }
            return resultMatrix;
        }

        public String PrintMatrix(int[,] matrix)
        {
            int lineLength = matrix.GetLength(0);
            int j = 0;
            String returnString = "\n| ";
            foreach (int item in matrix)
            {
                returnString += item;
                returnString += " | ";
                j++;
                if (j == lineLength)
                {
                    returnString += "\n";
                    for (int i = 0; i < lineLength * 5; i++)
                    {
                        returnString += "-";
                    }
                    returnString += "\n";
                    returnString += "| ";
                    j = 0;
                }
            }
            return returnString;
        }
    }

    public enum MatrixDimensions
    {
        DIMENSION_ONE,
        DIMENSION_TWO
    }
}
