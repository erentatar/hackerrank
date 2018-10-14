using System;
using System.Collections.Generic;
using System.Linq;

namespace PickingNumbers
{
    class Program
    {
        static int pickingNumbers(int[] a)
        {
            Dictionary<int, List<int>> list = new Dictionary<int, List<int>>();
            bool flag = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (!list.ContainsKey(a[i]))
                    list.Add(a[i], new List<int>());
                else
                    continue;

                for (int j = 0; j < a.Length; j++)
                {
                    flag = true;
                    if (i == j) continue;

                    if (Math.Abs(a[i] - a[j]) <= 1)
                    {
                        foreach (var item in list[a[i]])
                        {
                            if (Math.Abs(item - a[j]) > 1)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                            list[a[i]].Add(a[j]);
                    }
                }
            }
            
            int max = 0;
            foreach (var lst in list.Values)
            {
                if (max < lst.Count())
                    max = lst.Count();
            }
            return max + 1;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int result = pickingNumbers(a);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
