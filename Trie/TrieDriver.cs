using System;

namespace Trie
{
    class TrieDriver
    {
        static void Main(string[] args)
        {
            // Build out our trie
            string[] words = { "apple", "ape", "grape", "grapple", "these", "their", "there" };

            Trie trie = new Trie();

            foreach (string word in words)
            {
                trie.Insert(word);
            }

            // Search for some values
            Console.WriteLine("Trie contains the full word 'these': " + trie.Search("these"));
            Console.WriteLine("Trie contains the full word 'the': " + trie.Search("the"));
            Console.WriteLine("Trie contains the full word  apple': " + trie.Search("apple"));

            Console.WriteLine("Trie contains 'the': " + trie.StartsWith("the"));
            Console.WriteLine("Trie contains 'grap': " + trie.StartsWith("grap"));
            Console.WriteLine("Trie contains 'pe': " + trie.StartsWith("pe"));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
