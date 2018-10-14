using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckBalance
{
    class Program
    {
        // Complete the luckBalance function below.
        static int luckBalance(int k, int[][] contests)
        {
            int result = 0;
            var importantLucks = new SortedList<int, int>();
            for (int i = 0; i < contests.Length; i++)
            {
                if (contests[i][1] == 1)
                    importantLucks.Add(i, contests[i][0]);
                else if (contests[i][1] == 0)
                    result += contests[i][0];
            }

            var sortedImportantLucks = importantLucks.OrderByDescending(v => v.Value);

            foreach(var luck in sortedImportantLucks)
            {
                if (k > 0)
                {
                    result += luck.Value;
                    k--;
                }
                else
                {
                    result -= luck.Value;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] contests = new int[n][];

            for (int i = 0; i < n; i++)
            {
                contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
            }

            int result = luckBalance(k, contests);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
