using System;
using System.Linq;

namespace BreakingTheRecords
{
    class Program
    {
        static int[] breakingRecords(int[] score)
        {
            int first = score[0];
            int best = first, bestCount = 0, worst = first, worstCount = 0;

            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] > best)
                {
                    bestCount++;
                    best = score[i];
                }

                if (score[i] < worst)
                {
                    worstCount++;
                    worst = score[i];
                }
            }

            return new int[] { bestCount, worstCount };
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] score_temp = Console.ReadLine().Split(' ');
            int[] score = Array.ConvertAll(score_temp, Int32.Parse);
            int[] result = breakingRecords(score);
            Console.WriteLine(String.Join(" ", result));
            Console.ReadKey();
        }
    }
}
