using System;
using AlgorithmsLibrary;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            // test BST_PrintRange() method
            var root = new Node<int>(8);    
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);  
            Node<int>.BST_PrintRange(root, 5, 15);

        }
    }
}
