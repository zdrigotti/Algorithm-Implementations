using System;

namespace BinarySearchTree
{
    class RecursiveBinaryTree : IBinaryTree
    {
        public Node root { get; private set; }

        public RecursiveBinaryTree()
        {
            root = null;
        }

        /// <summary>
        /// Inserts a new node into the binary tree
        /// </summary>
        /// <param name="value">Value to insert</param>
        public void Insert(int value)
        {
            root = InsertInternal(root, value);
        }

        /// <summary>
        /// Inserts a new node into the binary tree
        /// </summary>
        /// <param name="node">Node to attempt to append to</param>
        /// <param name="value">Value to insert</param>
        /// <returns>Root node if not called recursively, new node when called recursively</returns>
        private Node InsertInternal(Node node, int value)
        {
            if (node == null)
            {
                node = new Node(value);
                return node;
            }

            if (value < node.Value)
            {
                node.Left = InsertInternal(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = InsertInternal(node.Right, value);
            }

            return node;
        }

        /// <summary>
        /// Delete a node based on a provided value
        /// </summary>
        /// <param name="node">Node to attempt to delete</param>
        /// <param name="value">Value to delete from the tree</param>
        /// <returns>Root node if not called recursively, new node when called recursively</returns>
        private Node DeleteInternal(Node node, int value)
        {
            if (node == null)
            {
                return node;
            }

            if (value < node.Value)
            {
                node.Left = DeleteInternal(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = DeleteInternal(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }

                node.Value = nextMinimum(node.Right);

                root.Right = DeleteInternal(root.Right, root.Value);
            }

            return node;
        }

        /// <summary>
        /// Helper function to find the next smallest value
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Smallest value down the tree from the provided node</returns>
        private int nextMinimum(Node node)
        {
            int minimum = node.Value;
            while (node.Left != null)
            {
                minimum = node.Left.Value;
                node = node.Left;
            }

            return minimum;
        }

        /// <summary>
        /// Finds the correct node given a search value, if it exists
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns>Corresponding node if found, null otherwise</returns>
        public Node Search(int value)
        {
            return SearchInternal(root, value);
        }

        /// <summary>
        /// Finds the correct node given a search value, if it exists
        /// </summary>
        /// <param name="node">Node to search from</param>
        /// <param name="value">Value to search for</param>
        /// <returns>Matching node if not called recursively, next node when called recursively</returns>
        private Node SearchInternal(Node node, int value)
        {
            if (node == null || node.Value == value)
            {
                return node;
            }

            if (value < node.Value)
            {
                return SearchInternal(node.Left, value);
            }

            return SearchInternal(node.Right, value);
        }

        /// <summary>
        /// Prints the node values in order
        /// </summary>
        public void PrintInOrder()
        {
            PrintInOrderInternal(root);
        }

        /// <summary>
        /// Prints the node values in order
        /// </summary>
        /// <param name="node">Root node if not called recursively, next node when called recursively</param>
        private void PrintInOrderInternal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintInOrderInternal(node.Left);

            Console.WriteLine(node.Value);

            PrintInOrderInternal(node.Right);
        }

        /// <summary>
        /// Prints the elements in pre order
        /// </summary>
        public void PrintPreOrder()
        {
            PrintPreOrderInternal(root);
        }

        /// <summary>
        /// Prints the elements in pre order
        /// </summary>
        /// <param name="node">Root node if not called recursively, next node when called recursively</param>
        private void PrintPreOrderInternal(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);
            PrintPreOrderInternal(node.Left);
            PrintPreOrderInternal(node.Right);
        }

        /// <summary>
        /// Prints the elements in post order
        /// </summary>
        public void PrintPostOrder()
        {
            PrintPostOrderInternal(root);
        }
        /// <summary>
        /// Prints the elements in post order
        /// </summary>
        /// <param name="node">Root node if not called recursively, next node when called recursively</param>
        private void PrintPostOrderInternal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintPostOrderInternal(node.Left);
            PrintPostOrderInternal(node.Right);

            Console.WriteLine(node.Value);
        }

        /// <summary>
        /// Prints the elements in reverse order
        /// </summary>
        public void PrintInReverseOrder()
        {
            PrintInReverseOrderInternal(root);
        }

        /// <summary>
        /// Prints the elements in reverse order
        /// </summary>
        /// <param name="node">Root node if not called recursively, next node when called recursively</param>
        public void PrintInReverseOrderInternal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintInReverseOrderInternal(node.Right);

            Console.WriteLine(node.Value);

            PrintInReverseOrderInternal(node.Left);
        }
    }
}
