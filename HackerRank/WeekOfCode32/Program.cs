using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeekOfCode32
{
    class Program
    {
        public static string S = "0";
        static void GenerateString()
        {
            string temp;
            while (S.Length <= 1000)
            {
                temp = S;
                temp = temp.Replace("1", "2");
                temp = temp.Replace("0", "1");
                temp = temp.Replace("2", "0");
                S = S + temp;
            }
        }
        static string Duplication(int x)
        {
            return S[x].ToString();
        }
        private static void Duplication()
        {
            GenerateString();
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                string result = Duplication(x);
                Console.WriteLine(result);
            }
        }
        static int GetMaxMonsters(int n, int hit, int t, int[] h)
        {
            long totalPower = long.Parse(hit.ToString()) * long.Parse(t.ToString());
            Array.Sort(h);
            int killed = 0;
            int i = 0;
            int len = h.Length;

            int d = 0, r = 0;
            while (totalPower > 0 && i < len)
            {
                d = h[i] / hit;
                r = h[i] % hit;

                if (r == 0)
                {
                    if (totalPower - d * hit >= 0)
                    {
                        killed++;
                        i++;
                        totalPower -= d * hit;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (totalPower - (d + 1) * hit >= 0)
                    {
                        killed++;
                        i++;
                        totalPower -= (d + 1) * hit;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return killed;
        }
        private static void FightMonsters()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int hit = Convert.ToInt32(tokens_n[1]);
            int t = Convert.ToInt32(tokens_n[2]);
            string[] h_temp = Console.ReadLine().Split(' ');
            int[] h = Array.ConvertAll(h_temp, Int32.Parse);
            int result = GetMaxMonsters(n, hit, t, h);
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            //Duplication();
            //FightMonsters();
            //CircularWalk();--yapamadık.
            Geometric_Trick();
            Console.ReadKey();
        }

        private static void Geometric_Trick()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            int result = GeometricTrick(s, n);
            Console.WriteLine(result);
        }
        static int GeometricTrick(string s, int n)
        {
            List<int> indexA = new List<int>();
            List<int> indexB = new List<int>();
            List<int> indexC = new List<int>();

            for (int m = 0; m < n; m++)
            {
                if (s[m] == 'a')
                    indexA.Add(m);
                else if (s[m] == 'b')
                    indexB.Add(m);
                else
                    indexC.Add(m);
            }

            if (indexA.Count == 0 || indexB.Count == 0 || indexC.Count == 0)
                return 0;

            int result = 0;
            foreach (var j in indexB)
            {
                int left = (int)Math.Pow(j + 1, 2);
                List<Tuple<int, int>> factors = new List<Tuple<int, int>>();
                for (int k = 1; k < Math.Sqrt(left); k++)
                {
                    if (left % k == 0)
                    {
                        factors.Add(new Tuple<int, int>(k, j / k));
                        factors.Add(new Tuple<int, int>(j / k, k));
                    }
                }

                foreach (var factor in factors)
                {
                    if ((s[factor.Item1] == 'a' && s[factor.Item2] == 'c') ||
                        (s[factor.Item1] == 'c' && s[factor.Item2] == 'a'))
                        result++;
                }
            }

            return result;
        }
        private static void CircularWalk()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int s = Convert.ToInt32(tokens_n[1]);
            int t = Convert.ToInt32(tokens_n[2]);
            string[] tokens_r_0 = Console.ReadLine().Split(' ');
            int r_0 = Convert.ToInt32(tokens_r_0[0]);
            int g = Convert.ToInt32(tokens_r_0[1]);
            int seed = Convert.ToInt32(tokens_r_0[2]);
            int p = Convert.ToInt32(tokens_r_0[3]);
            int result = CircularWalking(n, s, t, r_0, g, seed, p);
            Console.WriteLine(result);
        }
        private static int CircularWalking(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            if (s == t)
                return 0;

            //R yi üret
            int[] R = new int[n];
            R[0] = r_0;
            for (int i = 1; i < n; i++)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }

            int time = 0;


            return time;
        }
    }
}
