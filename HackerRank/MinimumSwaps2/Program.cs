using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace MinimumSwaps2
{
    class Program
    {
        // Complete the minimumSwaps function below.
        static int minimumSwaps(int[] arr)
        {
            int swap = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int index = Array.IndexOf(arr, i + 1);
                if (i != index)
                {
                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;
                    swap++;
                }
            }
            return swap;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = minimumSwaps(arr);

            Console.WriteLine(res);
            Console.ReadKey();
            //textWriter.WriteLine(res);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
