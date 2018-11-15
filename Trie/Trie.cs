namespace Trie
{
    class Trie
    {
        public Node root;
        
        public Trie()
        {
            root = new Node();
        }

        /// <summary>
        /// Inserts a new word into the trie
        /// </summary>
        /// <param name="word">Word to insert</param>
        public void Insert(string word)
        {
            Node currentNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                char key = word[i];

                currentNode.Put(key);
                currentNode = currentNode.Get(key);

                if (currentNode == null)
                {
                    currentNode = new Node();
                }
            }

            currentNode.IsEnd = true;
        }

        /// <summary>
        /// Searches for an exact word in the trie
        /// </summary>
        /// <param name="word">Word to search for</param>
        /// <returns>True if the word exists in the trie, false otherwise</returns>
        public bool Search(string word)
        {
            Node currentNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                char key = word[i];
                currentNode = currentNode.Get(key);
            }

            return currentNode != null && currentNode.IsEnd;
        }

        /// <summary>
        /// Searches for the word in the trie, but the word can be the
        /// prefix of a longer word
        /// </summary>
        /// <param name="word">Word to search for</param>
        /// <returns>True if the word exists in the trie, false otherwise</returns>
        public bool StartsWith(string word)
        {
            Node currentNode = root;

            for (int i = 0; i < word.Length; i++)
            {
                char key = word[i];
                currentNode = currentNode.Get(key);

                if (currentNode == null) { break; }
            }

            return currentNode != null;
        }
    }
}
