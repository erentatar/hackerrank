using System;
using System.Collections.Generic;
using System.IO;

namespace CastleOnTheGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            char[][] grid = new char[n][];

            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine().ToCharArray();
            }

            string[] startXStartY = Console.ReadLine().Split(' ');

            int startX = Convert.ToInt32(startXStartY[0]);

            int startY = Convert.ToInt32(startXStartY[1]);

            int goalX = Convert.ToInt32(startXStartY[2]);

            int goalY = Convert.ToInt32(startXStartY[3]);

            int result = minimumMoves(grid, startX, startY, goalX, goalY);

            textWriter.WriteLine(result);
            //Console.WriteLine(result);
            //Console.ReadKey();
            textWriter.Flush();
            textWriter.Close();
        }
        // Complete the minimumMoves function below.
        static int minimumMoves(char[][] grid, int startX, int startY, int goalX, int goalY)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(startX, startY));

            grid[startX][startY] = '+';

            while (queue.Count > 0)
            {
                var currentPoint = queue.Dequeue();

                if (currentPoint.X == goalX && currentPoint.Y == goalY)
                    return currentPoint.Depth;

                //x: row, y: column of the point

                //go to left: x fixed, y decreased by 1
                for (int y = currentPoint.Y - 1; y >= 0; y--)
                {
                    if (grid[currentPoint.X][y] == 'X') break;
                    if (grid[currentPoint.X][y] != '+')
                    {
                        queue.Enqueue(new Point(currentPoint.X, y, currentPoint.Depth + 1));
                        grid[currentPoint.X][y] = '+';
                    }
                }

                //go to right: x fixed, y increased by 1
                for (int y = currentPoint.Y + 1; y < grid.Length; y++)
                {
                    if (grid[currentPoint.X][y] == 'X') break;
                    if (grid[currentPoint.X][y] != '+')
                    {
                        queue.Enqueue(new Point(currentPoint.X, y, currentPoint.Depth + 1));
                        grid[currentPoint.X][y] = '+';
                    }
                }

                //go to top: x decreased by 1, y fixed
                for (int x = currentPoint.X - 1; x >= 0; x--)
                {
                    if (grid[x][currentPoint.Y] == 'X') break;
                    if (grid[x][currentPoint.Y] != '+')
                    {
                        queue.Enqueue(new Point(x, currentPoint.Y, currentPoint.Depth + 1));
                        grid[x][currentPoint.Y] = '+';
                    }
                }

                //go to down: x increased by 1, y fixed
                for (int x = currentPoint.X + 1; x < grid.Length; x++)
                {
                    if (grid[x][currentPoint.Y] == 'X') break;
                    if (grid[x][currentPoint.Y] != '+')
                    {
                        queue.Enqueue(new Point(x, currentPoint.Y, currentPoint.Depth + 1));
                        grid[x][currentPoint.Y] = '+';
                    }
                }
            }

            return -1;
        }

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Depth { get; set; }

            public Point(int x, int y, int depth = 0)
            {
                X = x;
                Y = y;
                Depth = depth;
            }
        }
    }
}
