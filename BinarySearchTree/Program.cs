using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main()
        {
            // Iterative usage
            IterativeBinaryTree iterativeTree = new IterativeBinaryTree();

            iterativeTree.Insert(10);
            iterativeTree.Insert(7);
            iterativeTree.Insert(14);
            iterativeTree.Insert(20);
            iterativeTree.Insert(1);
            iterativeTree.Insert(5);
            iterativeTree.Insert(8);

            Console.WriteLine("Printing in order iteratively:");
            iterativeTree.PrintInOrder();

            Node node = iterativeTree.Search(20);
            if (node != null)
            {
                Console.WriteLine("\nValue of 20 found iteratively");
            }

            node = iterativeTree.Search(15);
            if (node == null)
            {
                Console.WriteLine("\nValue of 15 not found iteratively");
            }

            // Recursive usage
            RecursiveBinaryTree recursiveTree = new RecursiveBinaryTree();

            recursiveTree.Insert(10);
            recursiveTree.Insert(7);
            recursiveTree.Insert(14);
            recursiveTree.Insert(20);
            recursiveTree.Insert(1);
            recursiveTree.Insert(5);
            recursiveTree.Insert(8);

            Console.WriteLine("\nPrinting in order recursively:");
            recursiveTree.PrintInOrder();

            Console.WriteLine("\nPrinting in reverse order recursively:");
            recursiveTree.PrintInReverseOrder();

            Console.WriteLine("\nPrinting in pre order recursively:");
            recursiveTree.PrintPreOrder();

            Console.WriteLine("\nPrinting in post order recursively:");
            recursiveTree.PrintPostOrder();
            
            node = recursiveTree.Search(20);
            if (node != null)
            {
                Console.WriteLine("\nValue of 20 found recursively");
            }            

            node = recursiveTree.Search(15);
            if (node == null)
            {
                Console.WriteLine("\nValue of 15 not found recursively");
            }
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
