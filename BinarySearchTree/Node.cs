namespace BinarySearchTree
{
    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        
        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="value">Value for the node</param>
        public Node(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
