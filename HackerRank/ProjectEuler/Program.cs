using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Euler004_LargestPalindromeProduct();
            //Euler003_LargestPrimeFactor();
            Console.ReadKey();
        }

        private static void Euler004_LargestPalindromeProduct()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<int> inputs = new List<int>();
            for (int a0 = 0; a0 < t; a0++)
            {
                inputs.Add(Convert.ToInt32(Console.ReadLine()));
            }
            var outputs = FindPalindrome(inputs);
            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        public static List<int> FindPalindrome(List<int> inputs)
        {
            var outputs = new List<int>();

            bool found = false;
            foreach (var input in inputs)
            {
                found = false;
                for (int i = input - 1; i >= 101101 && !found; i--)
                {
                    char[] charArray = i.ToString().ToCharArray();
                    Array.Reverse(charArray);
                    int reverse = Convert.ToInt32(new string(charArray));

                    if (i == reverse)
                    {
                        for (int j = 100; j < 1000; j++)
                        {
                            if (i % j == 0)
                            {
                                if ((i / j).ToString().Length == 3)
                                {
                                    outputs.Add(i);
                                    found = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return outputs;
        }

        private static void Euler003_LargestPrimeFactor()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<long> primes = new List<long>();
            for (int a0 = 0; a0 < t; a0++)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                primes.Add(GetLargestPrimeFactor(n));
            }
            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }
        }

        public static long GetLargestPrimeFactor(long n)
        {
            //Stack<int> factors = new Stack<int>();

            long num = 2;
            while (num * num <= n)
            {
                while (n % num == 0)
                {
                    if (n / num > 1)
                        n = n / num;
                    else break;
                }
                num++;
            }
            //for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            //{
            //    if (n % i == 0)
            //        factors.Push(i);
            //}

            //long factor = n;
            //while (factors.Count > 0)
            //{
            //    bool prime = true;
            //    factor = factors.Pop();

            //    for (int i = 2; i <= (int)Math.Sqrt(factor); i++)
            //    {
            //        if (factor % i == 0)
            //            prime = false;
            //    }

            //    if (prime)
            //        break;
            //}
            return n;
        }
    }
}
