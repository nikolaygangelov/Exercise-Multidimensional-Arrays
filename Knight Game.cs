using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            if (N < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] matrix = new char[N, N];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputOfMatrix = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                }
            }


            int countOfRemovals = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, N, matrix);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAttacking, colMostAttacking] = '0';
                    countOfRemovals++;
                }
            }

            Console.WriteLine(countOfRemovals);
            //for (int row = 1; row < matrix.GetLength(0) - 1; row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        if (matrix[row, col] == 'K')
            //        {
            //            if (matrix[row + 2, col + 1] == 'K' || matrix[row + 2, col - 1] == 'K')
            //            {
            //                countOfRemovals++;
            //            }
            //            else if (matrix[row - 2, col + 1] == 'K' || matrix[row - 2, col - 1] == 'K')
            //            {
            //                countOfRemovals++;
            //            }
            //            else if (matrix[row + 1, col + 2] == 'K' || matrix[row + 1, col - 2] == 'K')
            //            {
            //                countOfRemovals++;
            //            }
            //            else if (matrix[row - 1, col + 2] == 'K' || matrix[row - 1, col - 2] == 'K')
            //            {
            //                countOfRemovals++;
            //            }
            //        }
            //    }
            //}
        }

        public static int CountAttackedKnights(int row, int col, int N, char[,] matrix)
        {
            int attackedKnights = 0;
            //horizontal left-up
            if (isCellValid(row - 1, col - 2, N))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal left-down
            if (isCellValid(row + 1, col - 2, N))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal right-up
            if (isCellValid(row - 1, col + 2, N))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal right-down
            if (isCellValid(row + 1, col + 2, N))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical up-left
            if (isCellValid(row - 2, col - 1, N))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical up-right
            if (isCellValid(row - 2, col + 1, N))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical down-left
            if (isCellValid(row + 2, col - 1, N))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal down-right
            if (isCellValid(row + 2, col + 1, N))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        public static bool isCellValid(int row, int col, int N)
        {
            return
                row >= 0
                && row < N
                && col >= 0
                && col < N;
        }
    }
}
