using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    class Program
    {
        static void Main()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<string> inputs = new List<string>();
            for (int a0 = 0; a0 < t; a0++)
            {
                string s = Console.ReadLine();
                inputs.Add(s);
            }

            IsBalanced(inputs);
            Console.ReadKey();
        }

        static void IsBalanced(List<string> inputs)
        {
            List<string> outputs = new List<string>();
            Stack<char> temp = new Stack<char>();
            List<char> leftBrackets = new List<char> { '{', '[', '(' };
            List<char> rightBrackets = new List<char> { '}', ']', ')' };
            bool balanced = true;

            foreach (var input in inputs)
            {
                balanced = true;
                temp.Clear();

                foreach (var t in input)
                {
                    if (leftBrackets.Contains(t))
                        temp.Push(t);
                    else
                    {
                        if (temp.Count > 0)
                        {
                            var popped = temp.Pop();
                            if (rightBrackets.IndexOf(t) == leftBrackets.IndexOf(popped)) continue;
                            balanced = false;
                            break;
                        }
                        balanced = false;
                        break;
                    }
                }

                if (temp.Count > 0) balanced = false;

                outputs.Add(balanced ? "YES" : "NO");
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }
    }
}
