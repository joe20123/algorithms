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

        public List<Node<T>> BTree_DepthFirstTravesal_PreOrder(Node<T> root)
        {
            if (root == null)
                return null;
            if (root.LeftChild == null && root.RightChild == null)
                return new List<Node<T>>{root};
            if (root.LeftChild == null)
                root.LeftChild = root.RightChild;

            var output = new List<Node<T>>();
            var start = root;

            while (BTree_anyLeftChild(start))
            {
                output.Add(start);
                start = null;
            }
        }
        private bool BTree_anyLeftChild(Node<T> input)
        {
            if (input.LeftChild == null)
                return false;
            BTree_anyLeftChild(input.LeftChild);
            return true;
        }
    }



}
