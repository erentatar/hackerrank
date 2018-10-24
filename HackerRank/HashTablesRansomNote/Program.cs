using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTablesRansomNote
{
    class Program
    {
        // Complete the checkMagazine function below.
        static void checkMagazine(string[] magazine, string[] note)
        {
            bool match = false;
            var dictionary = magazine.GroupBy(m => m).ToDictionary(g => g.Key, g => g.Count());
            foreach (var n in note)
            {
                if (!dictionary.ContainsKey(n) || dictionary[n] <= 0)
                {
                    match = false;
                    break;
                }

                dictionary[n]--;
                match = true;
            }

            Console.WriteLine(match ? "Yes" : "No");
        }

        static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            checkMagazine(magazine, note);
        }
    }
}
