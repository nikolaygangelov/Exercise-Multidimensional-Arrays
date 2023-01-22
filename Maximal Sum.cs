using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputOfMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                }
            }

            int maxSumOfSubMatrix = 0;
            int indexOfRows = 0;
            int indexOfCols = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sumOfSubMatrix = 0;
                    for (int subRow = 0; subRow < 3; subRow++)
                    {
                        for (int subCol = 0; subCol < 3; subCol++)
                        {
                            sumOfSubMatrix += matrix[row + subRow, col + subCol];
                        }
                    }
                    if (sumOfSubMatrix > maxSumOfSubMatrix)
                    {
                        maxSumOfSubMatrix = sumOfSubMatrix;
                        indexOfRows = row;
                        indexOfCols = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSumOfSubMatrix}");

            for (int row = indexOfRows; row < indexOfRows + 3; row++)
            {
                for (int col = indexOfCols; col < indexOfCols + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
