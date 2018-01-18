using System;
using System.Linq;

namespace BirthdayChocolate
{
    class Program
    {
        static int solve(int n, int[] s, int d, int m)
        {
            int result = 0;

            for (int i = 0; i < n - m + 1; i++)
            {
                if (s.Skip(i).Take(m).Sum() == d)
                    result++;
            }

            return result;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] s_temp = Console.ReadLine().Split(' ');
            int[] s = Array.ConvertAll(s_temp, Int32.Parse);
            string[] tokens_d = Console.ReadLine().Split(' ');
            int d = Convert.ToInt32(tokens_d[0]);
            int m = Convert.ToInt32(tokens_d[1]);
            int result = solve(n, s, d, m);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
