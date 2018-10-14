using System;
using System.Collections.Generic;

namespace ZombieClusters
{
    class Program
    {
        class Result
        {
            public static int zombieCluster(List<string> zombies)
            {
                return 0;
            }

        }


        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int zombiesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> zombies = new List<string>();

            for (int i = 0; i < zombiesCount; i++)
            {
                string zombiesItem = Console.ReadLine();
                zombies.Add(zombiesItem);
            }

            int result = Result.zombieCluster(zombies);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
