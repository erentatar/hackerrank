using System;
using System.Linq;

namespace Encryption
{
    class Program
    {
        static string encryption(string s)
        {
            char[] array = s.Where(i => i != ' ').ToArray();

            int len = array.Length;
            int floor = (int)Math.Floor(Math.Sqrt(len));
            int ceiling = (int)Math.Ceiling(Math.Sqrt(len));

            int col = floor;
            while (col <= ceiling)
            {
                if (floor * col >= len)
                    break;

                col++;
            }

            if (col > ceiling)
                col = ceiling;

            string[] output = new string[col];
            int j = 0;
            for (int i = 0; i < col; i++)
            {
                string temp = string.Empty;
                for (int k = j; k < len; k = k + col)
                {
                    temp += array[k];
                }
                output[i] = temp;
                j++;
            }

            return string.Join(" ", output);
        }

        static void Main(String[] args)
        {
            string s = Console.ReadLine();
            string result = encryption(s);
            Console.WriteLine(result);
        }
    }
}
