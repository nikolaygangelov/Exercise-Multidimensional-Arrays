using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];

            int sumOfPrimaryDiagoanl = 0;
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
                sumOfPrimaryDiagoanl += matrix[row, row];
            }
            int sumOfSecondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumOfSecondaryDiagonal += matrix[N - row - 1, row];
            }
            Console.WriteLine(Math.Abs(sumOfPrimaryDiagoanl - sumOfSecondaryDiagonal));
        }
    }
}
