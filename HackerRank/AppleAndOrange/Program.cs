using System;
using System.Linq;

namespace AppleAndOrange
{
    class Program
    {
        static int[] appleAndOrange(int s, int t, int a, int b, int[] apple, int[] orange)
        {
            var countA = apple.Select(x => a + x).Where(x => x >= s && x <= t).Count();
            var countO = orange.Select(x => b + x).Where(x => x >= s && x <= t).Count();
            return new int[] { countA, countO };
        }

        static void Main(String[] args)
        {
            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);
            int[] result = appleAndOrange(s, t, a, b, apple, orange);
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
