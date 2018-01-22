using System;

namespace FormingMagicSquare
{
    class Program
    {
        static int formingMagicSquare(int[][] s)
        {
            int minCost = int.MaxValue, cost = 0;

            int[][,] magics = new int[8][,]
            {
                new int[,] { {8,1,6},{3,5,7},{4,9,2} },
                new int[,] { {6,1,8},{7,5,3},{2,9,4} },
                new int[,] { {4,9,2},{3,5,7},{8,1,6} },
                new int[,] { {2,9,4},{7,5,3},{6,1,8} },
                new int[,] { {8,3,4},{1,5,9},{6,7,2} },
                new int[,] { {4,3,8},{9,5,1},{2,7,6} },
                new int[,] { {6,7,2},{1,5,9},{8,3,4} },
                new int[,] { {2,7,6},{9,5,1},{4,3,8} }
            };

            for (int i = 0; i < magics.Length; i++)
            {
                cost = 0;
                for (int j = 0; j < magics[i].GetLength(0); j++)
                {
                    for (int k = 0; k < magics[i].GetLength(1); k++)
                    {
                        cost += Math.Abs(s[j][k] - magics[i][j, k]);
                    }
                }

                if (cost < minCost)
                    minCost = cost;
            }

            return minCost;
        }

        static void Main(String[] args)
        {
            int[][] s = new int[3][];
            for (int s_i = 0; s_i < 3; s_i++)
            {
                string[] s_temp = Console.ReadLine().Split(' ');
                s[s_i] = Array.ConvertAll(s_temp, Int32.Parse);
            }
            int result = formingMagicSquare(s);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
