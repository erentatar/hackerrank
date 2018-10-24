using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAndBobsSillyGame
{
    class Program
    {
        static string sillyGame(int n)
        {
            bool[] numbers = new bool[n-1];

            for (int i = 0; i < n; i++)
            {
                if ((i + 2) * (i + 2) > n)
                    break;

                int k = 1;
                while ((i + 2) * k <= n)
                {
                    if ((i + 2) * k != i + 2)
                        numbers[((i + 2) * k) - 2] = true;
                    k++;
                }
            }

            return numbers.Count(t => t == false) % 2 == 0 ? "Bob" : "Alice";
        }

        static void Main(string[] args)
        {
            int g = Convert.ToInt32(Console.ReadLine());

            for (int gItr = 0; gItr < g; gItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                string result = sillyGame(n);

                Console.WriteLine(result);
            }
        }
    }
}
