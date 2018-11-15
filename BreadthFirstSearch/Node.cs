using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Node
    {
        public List<Node> Children { get; private set; }
        public int Value { get; private set; }

        public Node(int value)
        {
            Value = value;
            Children = new List<Node>();
        }

        /// <summary>
        /// Adds a new child node
        /// </summary>
        /// <param name="child">Child node to add</param>
        public void AddChild(Node child)
        {
            Children.Add(child);
        }
        
        public override bool Equals(object obj)
        {
            Node comparisionNode = (Node)obj;
            return Value == comparisionNode.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
