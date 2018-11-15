namespace Trie
{
    class Node
    {
        const int MAX_CHILDREN = 26;

        public Node[] Children = new Node[MAX_CHILDREN];
        public bool IsEnd;        
        
        public Node()
        {            
            IsEnd = false;

            for (int i = 0; i < MAX_CHILDREN; i++)
            {
                Children[i] = null;
            }
        }

        /// <summary>
        /// Checks if the node contains a particular child character
        /// </summary>
        /// <param name="key">Character to check</param>
        /// <returns>True if the node contains the child character, false otherwise</returns>
        public bool ContainsKey(char key)
        {
            if (Children[key - 'a'] != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a particular child character
        /// </summary>
        /// <param name="key">Character to retrieve</param>
        /// <returns>Object containing the child node, could be null</returns>
        public Node Get(char key)
        {
            return Children[key - 'a'];
        }

        /// <summary>
        /// Attempts to insert a child character
        /// </summary>
        /// <param name="key">Character to insert</param>
        public void Put(char key)
        {
            int index = key - 'a';

            if (!ContainsKey(key))
            {
                Children[index] = new Node();
            }
        }
    }
}
