using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinAbsoluteDifference
{
    class Program
    {
        // Complete the minimumAbsoluteDifference function below.
        static int minimumAbsoluteDifference(int[] arr)
        {
            Array.Sort(arr);
            int min = Int32.MaxValue;
            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i] - arr[i - 1]) < min)
                    min = Math.Abs(arr[i] - arr[i - 1]);
            }
            return min;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = minimumAbsoluteDifference(arr);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
