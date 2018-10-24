using System;
using System.Collections.Generic;

namespace Contacts
{
    class Program
    {
        public class Trie
        {
            public int WordCount { get; set; }
            public bool IsEnd { get; set; }
            public Trie[] Series = new Trie[26];
        }

        private static void AddWord(Trie trie, string word)
        {
            var tempTrie = trie;

            for (int i = 0; i < word.Length; i++)
            {
                char character = word[i];

                //In series, check the position of character,
                //if it is already filled then check the series of filled Trie object.
                //if it is not filled then create new TrieContainer object and place it at correct position, and check
                //if it is end of the word, then mark isEnd = true or else false;
                if (tempTrie.Series[character - 97] != null)
                {
                    if (word.Length - 1 == i)
                    {
                        //if word is found till last character, then mark the end as true.
                        tempTrie.Series[character - 97].IsEnd = true;
                    }

                    tempTrie.Series[character - 97].WordCount++;
                }
                else
                {
                    Trie newTrie = new Trie();
                    newTrie.IsEnd = word.Length - 1 == i;
                    newTrie.WordCount++;
                    tempTrie.Series[character - 97] = newTrie;
                }

                tempTrie = tempTrie.Series[character - 97];
            }
        }

        private static int FindNumberOfWordsStartsWith(Trie trie, string prefix)
        {
            var tempTrie = trie;
            bool isPrefixExist = false;

            for (int i = 0; i < prefix.Length; i++)
            {
                isPrefixExist = false;
                char p = prefix[i];

                if (tempTrie.Series[p - 97] != null)
                {
                    tempTrie = tempTrie.Series[p - 97];
                    isPrefixExist = true;
                }

                if (!isPrefixExist)
                    break;
            }

            if (!isPrefixExist) return 0;

            //result = FindNumberOfCompleteWords(tempTrie);
            return tempTrie.WordCount;
        }

        private static int FindNumberOfCompleteWords(Trie trie)
        {
            int result = 0;

            if (trie.IsEnd)
                result++;

            for (int i = 0; i < 26; i++)
            {
                if (trie.Series[i] != null)
                    result += FindNumberOfCompleteWords(trie.Series[i]);
            }

            return result;
        }

        static List<int> contacts(string[][] queries)
        {
            Trie trie = new Trie();
            List<int> result = new List<int>();

            for (int i = 0; i < queries.Length; i++)
            {
                if (queries[i][0] == "add")
                    AddWord(trie, queries[i][1]);
                else
                    result.Add(FindNumberOfWordsStartsWith(trie, queries[i][1]));
            }

            return result;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int queriesRows = Convert.ToInt32(Console.ReadLine());

            string[][] queries = new string[queriesRows][];

            for (int queriesRowItr = 0; queriesRowItr < queriesRows; queriesRowItr++)
            {
                queries[queriesRowItr] = Console.ReadLine().Split(' ');
            }

            var result = contacts(queries);

            //textWriter.WriteLine(string.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();

            result.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
