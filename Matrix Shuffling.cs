using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputOfMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputParameters = command.Split();
                string commandType = inputParameters[0];

                if (commandType != "swap" || inputParameters.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(inputParameters[1]);
                int col1 = int.Parse(inputParameters[2]);
                int row2 = int.Parse(inputParameters[3]);
                int col2 = int.Parse(inputParameters[4]);

                if (row1 < 0 || row2 < 0 || row1 >= matrix.GetLength(0) || row2 >= matrix.GetLength(0))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (col1 < 0 || col2 < 0 || col1 >= matrix.GetLength(1) || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string swapElement = matrix[row1, col1];//0,0 = 1
                matrix[row1, col1] = matrix[row2, col2];//1 = 1,1 = 5
                matrix[row2, col2] = swapElement;//5 = 0,0 = 1

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
