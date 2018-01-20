using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ElectronicsShop
{
    class Program
    {
        static int getMoneySpent(int[] keyboards, int[] drives, int s)
        {
            int max = -1;
            foreach (int k in keyboards)
            {
                foreach (int d in drives.Where(d => d + k <= s))
                {
                    if (d + k > max)
                        max = d + k;

                    if (max == s)
                        return max;
                }
            }
            return max;
        }

        static void Main(String[] args)
        {
            string[] tokens_s = ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int n = Convert.ToInt32(tokens_s[1]);
            int m = Convert.ToInt32(tokens_s[2]);
            string[] keyboards_temp = ReadLine().Split(' ');
            int[] keyboards = Array.ConvertAll(keyboards_temp, Int32.Parse);
            string[] drives_temp = ReadLine().Split(' ');
            int[] drives = Array.ConvertAll(drives_temp, Int32.Parse);
            //  The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items
            int moneySpent = getMoneySpent(keyboards, drives, s);
            Console.WriteLine(moneySpent);
            Console.ReadKey();
        }

        private static string ReadLine()
        {
            Stream inputStream = Console.OpenStandardInput(5120);
            byte[] bytes = new byte[5120];
            int outputLength = inputStream.Read(bytes, 0, 5120);
            //Console.WriteLine(outputLength);
            char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            return new string(chars);
        }
    }
}
