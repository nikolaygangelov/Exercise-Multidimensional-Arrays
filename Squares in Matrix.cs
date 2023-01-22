using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lengthOfRows = rowAndCols[0];
            int lengthOfCols = rowAndCols[1];

            char[,] matrix = new char[lengthOfRows, lengthOfCols];
            for (int row = 0; row < lengthOfRows; row++)
            {
                char[] inputOfMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < lengthOfCols; col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                }
            }

            int countOfSubMatrix = 0;
            char previousCharacter = ' ';
            
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                previousCharacter = ' ';
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int countOfEquals = 0;
                    previousCharacter = ' ';
                    for (int subRow = 0; subRow < 2; subRow++)
                    {
                        for (int subCol = 0; subCol < 2; subCol++)
                        {
                            if (matrix[row + subRow, col + subCol] == previousCharacter)
                            {
                                countOfEquals++;
                                if (countOfEquals == 3)
                                {
                                    countOfSubMatrix++;
                                }
                            }
                            else
                            {
                                previousCharacter = matrix[row + subRow, col + subCol];
                            }
                        }
                    }
                }
            }
            Console.WriteLine(countOfSubMatrix);
        }
    }
}
