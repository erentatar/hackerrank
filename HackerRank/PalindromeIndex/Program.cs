using System;
using System.Collections.Generic;

namespace PalindromeIndex
{
    class Program
    {
        static int palindromeIndex(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] != s[j])
                {
                    if (IsPalindrome(s, i + 1, j))
                        return i;

                    if (IsPalindrome(s, i, j - 1))
                        return j;
                }
            }
            return -1;
        }

        private static bool IsPalindrome(string s, int start, int end)
        {
            for (int i = start, j = end; i < j; i++, j--)
            {
                if (s[i] != s[j])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<int>();

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                outputs.Add(palindromeIndex(s));
            }

            outputs.ForEach(s => Console.WriteLine(s));
            Console.ReadKey();
        }
    }
}
