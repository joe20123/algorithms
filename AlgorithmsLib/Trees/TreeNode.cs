using System.Collections.Generic;

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
    }



}
