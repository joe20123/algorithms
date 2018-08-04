using System.Collections.Generic;
using System;

namespace AlgorithmsLibrary
{
    public class Node<T> 
    {
        public Node(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public Node<T> LeftChild { get; set; }     
        public Node<T> RightChild { get; set; }

        public static List<Node<T>> BreadthTravelsal(Node<T> root)
        {
            if (root == null) 
                return null;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            var output = new List<Node<T>>();
            while (queue.Count != 0)
            {
                var a = queue.Dequeue();
                output.Add(a);

                if (a.LeftChild != null)
                    queue.Enqueue(a.LeftChild);
                if (a.RightChild != null)
                    queue.Enqueue(a.RightChild);
            }
            return output;
        }

        public static List<T> BTree_DepthFirstTravesal_PreOrder(Node<T> root)
        {
            var output = new List<T>();
            BTree_PreOrder(root, output);

            return output;
        }
        private static void BTree_PreOrder(Node<T> input, List<T> output)
        {
            if (input == null)
                return;
            output.Add(input.Data);
            
            BTree_PreOrder(input.LeftChild, output);
            BTree_PreOrder(input.RightChild, output);
        }

        // BST - Binary search tree
        // return the node where input node will be inserted under (header)
        public static Node<int> BST_insert(Node<int> head, Node<int> node)
        {
            if (head == null)
                return node;

            Node<int> parent = null;
            Node<int> current = head;
            while (current != null)
            {
                if (node.Data <= current.Data)
                {
                    parent = current;
                    current = current.LeftChild;
                } 
                else if (node.Data > current.Data)
                {
                    parent = current;
                    current = current.RightChild; 
                }
            }
            return parent;
        }

        public static bool BST_NodeExists(Node<int> head, Node<int> input)
        {
            if (head == null)
                return false;

            Node<int> current = head;
            while (current != null)
            {
                if (input.Data == current.Data)
                    return true;
                if (input.Data < current.Data)
                {
                    current = current.LeftChild;
                } 
                else if (input.Data > current.Data)
                {
                    current = current.RightChild; 
                }
            }
            return false;
        }

        public static int BST_findMinNode(Node<int> head) 
        {
            if (head == null) 
                return -999;
            if (head.LeftChild == null)
                return -999;

            var min = int.MaxValue;

            var left = head.LeftChild;
            while (left != null)
            {
                if (min > left.Data)
                    min = left.Data;

                left = left.LeftChild;
            }
            return min;

        }

        // max depth really means to find the max number
        public static int BST_max_depth(Node<int> head)
        {
            if (head == null)
                return -1;
            var max = int.MinValue;

            var current = head;
            var counter = 0;

            while (current.RightChild != null)
            {
                if (current.RightChild.Data > max)
                {
                    max = current.RightChild.Data;
                    counter += 1;
                }
                current = current.RightChild;
            }
            return counter;
        }

        public static void BST_Mirror(Node<int> head)
        {
            if (head == null)
                return;
         
            BST_Mirror(head.LeftChild);
            BST_Mirror(head.RightChild);

            (head.LeftChild, head.RightChild) = (head.RightChild, head.LeftChild);
        }

        public static void BST_PrintRange(Node<int> head, int low, int high)
        {
            if (head == null) return;

            if (low <= head.Data)
                BST_PrintRange(head.LeftChild, low, high);
            
            if (low <= head.Data && head.Data <= high)
                Console.WriteLine(head.Data);

            if (high > head.Data)
                BST_PrintRange(head.RightChild, low, high);
        }
    }



}
