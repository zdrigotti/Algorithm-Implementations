using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class IterativeBinaryTree : IBinaryTree
    {
        public Node root { get; private set; }

        public IterativeBinaryTree()
        {
            root = null;
        }

        /// <summary>
        /// Inserts a new node into the binary tree
        /// </summary>
        /// <param name="value">Value to insert</param>
        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = root;

            while (true)
            {
                if (newNode.Value < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        return;
                    }

                    current = current.Left;
                }
                else if (newNode.Value > current.Value)
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        return;
                    }

                    current = current.Right;
                }
            }
        }

        /// <summary>
        /// Finds the correct node given a search value, if it exists
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns>Corresponding node if found, null otherwise</returns>
        public Node Search(int value)
        {
            Node currentNode = root;

            while (true)
            {
                if (currentNode == null || currentNode.Value == value)
                {
                    return currentNode;
                }
                else if (currentNode.Value > value)
                {
                    currentNode = currentNode.Left;
                }
                else if (currentNode.Value < value)
                {
                    currentNode = currentNode.Right;
                }
            }
        }

        /// <summary>
        /// Prints the node values in order
        /// </summary>
        public void PrintInOrder()
        {
            if (root == null)
            {
                return;
            }

            Stack<Node> stack = new Stack<Node>();
            Node currentNode = root;

            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }

                currentNode = stack.Pop();

                Console.WriteLine(currentNode.Value);

                currentNode = currentNode.Right;
            }
        }
    }
}
