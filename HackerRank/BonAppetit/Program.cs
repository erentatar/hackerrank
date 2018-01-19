using System;
using System.Linq;

namespace BonAppetit
{
    class Program
    {
        static void bonAppetit(int n, int k, int b, int[] ar)
        {
            var actual = (ar.Sum() - ar[k]) / 2;
            if (b > actual)
                Console.WriteLine(b - actual);
            else if (b == actual)
                Console.WriteLine("Bon Appetit");
        }

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int b = Convert.ToInt32(Console.ReadLine());
            bonAppetit(n, k, b, ar);
            //Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
