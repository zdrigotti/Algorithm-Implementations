using System;
using System.Collections.Generic;

namespace DepthFirstSearch
{
    class DepthFirstSearch
    {
        /// <summary>
        /// Given a root node of a tree, iteratively searches for
        /// the specified goal value
        /// </summary>
        /// <param name="root">Root node of a tree</param>
        /// <param name="goal">Goal value to serach for</param>
        public static void DFSIterative(Node root, int goal)
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();

                if (node.Value == goal)
                {
                    Console.WriteLine("Goal found");
                    return;
                }

                foreach (Node child in node.Children)
                {
                    if (!visited.Contains(child) && !stack.Contains(child))
                    {
                        stack.Push(child);
                    }
                }

                visited.Add(node);
            }

            Console.WriteLine("Goal not found");
        }

        /// <summary>
        /// Given a root node of a tree, recursively searches for
        /// the specified goal value
        /// </summary>
        /// <param name="root">Root node of a tree</param>
        /// <param name="goal">Goal value to serach for</param>
        public static void DFSRecursive(Node node, int goal)
        {
            DFSRucursiveInternal(node, goal, new HashSet<Node>());
        }

        /// <summary>
        /// Given a root node of a tree, recursively searches for
        /// the specified goal value
        /// </summary>
        /// <param name="root">Root node of a tree</param>
        /// <param name="goal">Goal value to serach for</param>
        /// <param name="visited">Set of visited nodes</param>
        private static void DFSRucursiveInternal(Node node, int goal, HashSet<Node> visited)
        {
            visited.Add(node);

            if (node.Value == goal)
            {
                Console.WriteLine("Goal found");
                return;
            }

            foreach (Node child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    DFSRucursiveInternal(child, goal, visited);
                }
            }
        }

        static void Main(string[] args)
        {
            // Construct our tree
            Node root = new Node(10);
            Node node11 = new Node(11);
            Node node12 = new Node(8);
            Node node13 = new Node(5);
            root.AddChild(node11);
            root.AddChild(node12);
            root.AddChild(node13);

            Node node21 = new Node(1);
            Node node22 = new Node(3);
            Node node23 = new Node(4);
            Node node24 = new Node(12);
            node11.AddChild(node21);
            node12.AddChild(node22);
            node12.AddChild(node23);
            node13.AddChild(node23);
            node13.AddChild(node24);

            Node node31 = new Node(80);
            Node node32 = new Node(71);

            node23.AddChild(node31);
            node24.AddChild(node32);

            // Try a few searches
            DFSIterative(root, 1);
            DFSRecursive(root, 1);

            DFSIterative(root, 50);
            DFSRecursive(root, 50);
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
