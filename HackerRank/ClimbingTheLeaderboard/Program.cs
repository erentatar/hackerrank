using System;

namespace ClimbingTheLeaderboard
{
    class Program
    {
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {

            int[] ranks = new int[alice.Length];

            int cumulativeRank = 0, j = 0;
            int num = int.MinValue;

            for (int i = alice.Length - 1; i >= 0; i--)
            {
                while (j < scores.Length && scores[j] > alice[i])
                {
                    if (num != scores[j])
                    {
                        cumulativeRank++;
                        num = scores[j];
                    }

                    j++;
                }
                ranks[i] = cumulativeRank + 1;
            }

            return ranks;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] scores_temp = Console.ReadLine().Split(' ');
            int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
            int m = Convert.ToInt32(Console.ReadLine());
            string[] alice_temp = Console.ReadLine().Split(' ');
            int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);
            int[] result = climbingLeaderboard(scores, alice);
            Console.WriteLine(String.Join("\n", result));
            Console.ReadKey();
        }
    }
}
