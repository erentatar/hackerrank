using System;
using System.Linq;

namespace SockMerchant
{
    class Program
    {
        static int sockMerchant(int n, int[] ar)
        {
            var pairs = from a in ar
                        group a by a into g
                        where g.Count() > 1
                        select g.Count();

            return pairs.Sum(p => p / 2);
            
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int result = sockMerchant(n, ar);
            Console.WriteLine(result);
        }
    }
}
