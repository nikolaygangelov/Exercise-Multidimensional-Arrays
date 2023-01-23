using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            long rows = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];
            for (long row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                if (row == 0)
                {
                    continue;
                }
                if (jaggedArray[row].Length == jaggedArray[row - 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                    jaggedArray[row - 1] = jaggedArray[row - 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x / 2).ToArray();
                    jaggedArray[row - 1] = jaggedArray[row - 1].Select(x => x / 2).ToArray();
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputParameters = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandType = inputParameters[0];
                int row = int.Parse(inputParameters[1]);
                int col = int.Parse(inputParameters[2]);
                int value = int.Parse(inputParameters[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    continue;
                }

                if (commandType == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (commandType == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}
