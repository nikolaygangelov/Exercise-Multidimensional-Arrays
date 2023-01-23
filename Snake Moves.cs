using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string inputOfMatrix = Console.ReadLine();//SoftUni
            
            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];//5, 6
            int currentWordIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)//0,1
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentWordIndex == inputOfMatrix.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = inputOfMatrix[currentWordIndex];//SoftUn
                        currentWordIndex++;
                    }
                }
                else if (row % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == inputOfMatrix.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = inputOfMatrix[currentWordIndex];//inUtfoS
                        currentWordIndex++;
                    }
                }   
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
