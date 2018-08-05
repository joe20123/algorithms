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

        //?? need to revise
        // max depth really means to find the max number
        public static int BST_max_depth(Node<int> head)
        {
            if (head == null)
                return -1;
            var max = int.MinValue;
            var min = int.MaxValue;

            var current = head;
            var counter = 0;
            var current_left = head;
            var counter_left = 0;

            while (current.RightChild != null)
            {
                if (current.RightChild.Data > max)
                {
                    max = current.RightChild.Data;
                    counter += 1;
                }
                current = current.RightChild;
            }

            while (current_left.LeftChild != null)
            {
                if (current_left.LeftChild.Data <= min)
                {
                    max = current_left.LeftChild.Data;
                    counter_left += 1;
                }
                current_left = current_left.LeftChild;
            }
            return Math.Max(counter, counter_left);
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

        public static bool is_BinarySearchTree(Node<int> head, int min, int max)
        {
            if (head == null) return true;

            if (head.Data <= min || head.Data > max)
                return false;

            return is_BinarySearchTree(head.LeftChild, min, head.Data)
                && is_BinarySearchTree(head.RightChild, head.Data, max);
        }

        public static bool BST_hasPathSum(Node<int> head, int sum)
        {
            if (head.LeftChild == null && head.RightChild == null)
                return head.Data == sum;
            
            int subSum = sum - head.Data;
            if(head.LeftChild != null)
            {
                if (BST_hasPathSum(head.LeftChild, subSum))
                    return true;
            }
            if (head.RightChild != null)
            {
                if (BST_hasPathSum(head.RightChild, subSum))
                    return true;
            }
            return false;
        }

    }



}
