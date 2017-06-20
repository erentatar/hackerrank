using System;
using System.Collections.Generic;
using System.Linq;

namespace BetweenTwoSets
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse); //size of n
            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse); //size of m

            //find min of array b
            int minB = 100;
            for (int i = 0; i < m; i++)
            {
                if (b[i] < minB)
                    minB = b[i];
            }

            //find all common factors of numbers in array b
            List<int> factors = new List<int>() { 1 };
            for (int i = 2; i <= minB; i++)
            {
                int j = 0;
                for (; j < m; j++)
                {
                    if (b[j] % i != 0)
                        break;
                }

                if (j == m)
                    factors.Add(i);
            }

            //find all common factors which are divisible by all of the numbers in array a
            for (int i = 0; i < n; i++)
            {
                for (int j = factors.Count() - 1; j >= 0; j--)
                {
                    if (factors[j] % a[i] != 0)
                        factors.Remove(factors[j]);
                }
            }

            Console.WriteLine(factors.Count);
        }
    }
}
