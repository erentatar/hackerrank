using System;
using System.Collections.Generic;

namespace BigSorting
{
    class Program
    {
        static string[] bigSorting(string[] arr)
        {
            Array.Sort(arr, new StringComparer());
            return arr;
        }

        public class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length == y.Length)
                    return string.Compare(x, y, StringComparison.Ordinal);
                else
                    return x.Length - y.Length;
            }
        }
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[n];
            for (int arr_i = 0; arr_i < n; arr_i++)
            {
                arr[arr_i] = Console.ReadLine();
            }
            string[] result = bigSorting(arr);
            Console.WriteLine(String.Join("\n", result));
            Console.ReadKey();

        }
    }
}
