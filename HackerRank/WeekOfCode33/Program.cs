using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode33
{
    class Program
    {
        static void Main(string[] args)
        {
            PatternCountChallenge();
        }

        private static void PatternCountChallenge()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                int result = PatternCount(s);
                Console.WriteLine(result);
            }
        }

        private static int PatternCount(string s)
        {
            int zeros = 0, matched = 0;
            bool first = false;

            int firstIndex = s.IndexOf("1");
            if (firstIndex < 0) return 0;

            first = true;
            for (int i = firstIndex + 1; i < s.Length; i++)
            {
                if (s[i] == '0' && first)
                {
                    zeros++;
                }
                else if (s[i] == '1' && zeros > 0)
                {
                    matched++;               
                    zeros = 0;
                }
                else if (s[i] == '1' && zeros == 0)
                {
                    first = true;
                }
                else
                {
                    zeros = 0;
                    first = false;
                }
            }

            return matched;
        }
    }
}
