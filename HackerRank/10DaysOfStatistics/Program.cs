using System;
using System.Collections.Generic;
using System.Linq;

namespace _10DaysOfStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day0_1();
            //Day0_2();
            //Day1_1();
            Day1_2();
            Console.ReadKey();
        }

        private static void Day1_2()
        {//INTERQUARTILE RANGE

        }

        private static void Day1_1()
        {//QUARTILES
            int q1, q2, q3;

            int n = Convert.ToInt32(Console.ReadLine());
            string[] xTemp = Console.ReadLine().Split(' ');
            int[] x = Array.ConvertAll(xTemp, Int32.Parse);

            Array.Sort(x);
            q2 = Convert.ToInt32(FindMedian(x, n));

            int[] x1 = new int[n / 2]; //first-half
            int[] x2 = new int[n / 2]; //second-half
            int i = 0, j = n - 1;
            while (x[i] < q2)
            {
                x1[i] = x[i];
                i++;
            }

            i = 0;
            while (x[j] > q2)
            {
                x2[i] = x[j];
                j--;
                i++;
            }

            q1 = Convert.ToInt32(FindMedian(x1, n / 2));
            q3 = Convert.ToInt32(FindMedian(x2, n / 2));

            Console.WriteLine(q1);
            Console.WriteLine(q2);
            Console.WriteLine(q3);
        }

        private static void Day0_2()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] xTemp = Console.ReadLine().Split(' ');
            string[] wTemp = Console.ReadLine().Split(' ');
            int[] x = Array.ConvertAll(xTemp, Int32.Parse);
            int[] w = Array.ConvertAll(wTemp, Int32.Parse);

            Console.WriteLine(FindWeightedMean(x, w, n));
        }

        public static string FindWeightedMean(int[] x, int[] w, int n)
        {
            int sumA = 0, sumB = 0;
            for (int i = 0; i < n; i++)
            {
                sumA += x[i] * w[i];
                sumB += w[i];
            }
            return String.Format("{0:0.0}", Math.Round((decimal)sumA / sumB, 1));
        }

        private static void Day0_1()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] temp = Console.ReadLine().Split(' ');
            int[] array = Array.ConvertAll(temp, Int32.Parse);

            Console.WriteLine(FindMean(array, n));
            Console.WriteLine(FindMedian(array, n));
            Console.WriteLine(FindMode(array, n));
        }

        private static int FindMode(int[] array, int n)
        {
            return array.GroupBy(x => x).OrderByDescending(g => g.Count()).ThenBy(y => y.Key).First().Key;
        }

        private static float FindMedian(int[] array, int n)
        {
            Array.Sort(array);

            if (n % 2 == 0)
                return (float)(array[n / 2 - 1] + array[n / 2]) / 2;
            else
                return array[n / 2 - 1 / 2];
        }

        private static float FindMean(int[] array, int n)
        {
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
            }

            return sum / n;
        }
    }
}
