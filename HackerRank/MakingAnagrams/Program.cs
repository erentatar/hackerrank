using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnagrams
{
    class Program
    {
        // Complete the makeAnagram function below.
        static int makeAnagram(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;

            var dictionaryA = a.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
            var dictionaryB = b.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());

            int deletion = 0;

            if (lenB < lenA)
            {
                foreach (var pairB in dictionaryB)
                {
                    if (dictionaryA.ContainsKey(pairB.Key))
                    {
                        deletion += Math.Abs(pairB.Value - dictionaryA[pairB.Key]);
                        dictionaryA.Remove(pairB.Key);
                    }
                    else
                    {
                        deletion += pairB.Value;
                    }
                }

                deletion += dictionaryA.Sum(i => i.Value);
            }
            else
            {
                foreach (var pairA in dictionaryA)
                {
                    if (dictionaryB.ContainsKey(pairA.Key))
                    {
                        deletion += Math.Abs(pairA.Value - dictionaryB[pairA.Key]);
                        dictionaryB.Remove(pairA.Key);
                    }
                    else
                    {
                        deletion += pairA.Value;
                    }
                }

                deletion += dictionaryB.Sum(i => i.Value);
            }

            return deletion;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string a = Console.ReadLine();

            string b = Console.ReadLine();

            int res = makeAnagram(a, b);

            //textWriter.WriteLine(res);

            //textWriter.Flush();
            //textWriter.Close();
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
