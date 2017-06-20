using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorldCodeSprint11
{
    class Program
    {
        static void Main(string[] args)
        {
            Numeric_String();
            Console.ReadLine();
        }

        static void Numeric_String()
        {
            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[300000];
            int outputLength = inputStream.Read(bytes, 0, 300000);
            char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            List<char> mainChars = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != '\r' && chars[i] != '\n')
                {
                    mainChars.Add(chars[i]);
                }
            }
            string s = string.Join("", mainChars.ToArray());
            string[] tokens_k = Console.ReadLine().Split(' ');
            int k = Convert.ToInt32(tokens_k[0]);
            int b = Convert.ToInt32(tokens_k[1]);
            int m = Convert.ToInt32(tokens_k[2]);
            int result = GetMagicNumber(s, k, b, m);
            Console.WriteLine(result);
        }

        static int GetMagicNumber(string s, int k, int b, int m)
        {
            List<string> subStr = new List<string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                subStr.Add(s.Substring(i, k));
                if (i + k == s.Length)
                    break;
            }

            List<long> converted = new List<long>();
            foreach (var sub in subStr)
            {
                long c = 0;
                for (int i = 0; i < k; i++)
                {
                    c += Convert.ToInt64(sub.Substring(i, 1)) * (long)Math.Pow(b, k - 1 - i);
                }
                converted.Add(c);
            }

            List<int> modulo = new List<int>();
            foreach (var conv in converted)
            {
                modulo.Add(Convert.ToInt32(conv % m));
            }

            return modulo.Sum();
        }
    }
}
