using System;

namespace BinarySearchTree
{
    interface IBinaryTree
    {
        // Property signatures
        Node root { get; }
        
        // Function signatures
        void Insert(int value);
        Node Search(int value);
        void PrintInOrder();
    }
}
