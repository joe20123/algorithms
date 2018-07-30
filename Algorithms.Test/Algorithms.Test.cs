using System;
using Xunit;
using AlgorithmsLibrary;
using System.Linq;

using System.Collections.Generic;

namespace Algorithms.Test
{
    public class AlgorithmsLibTest
    {
        [Theory]
        [InlineData(321, 6)]
        [InlineData(1, 1)]
        [InlineData(978, 24)]
        [InlineData(5434, 16)]
        public void Sum_ShouldProduceSumOfTheDigits(int input, int expected)
        {
            // arrange
            AlgorithmsLib al = new AlgorithmsLib();
            // act
            int result = al.sum(input);
            // assert
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData(new int[]{4, 2, 1}, new int[]{4,2}, new int[]{1})]
        [InlineData(new int[]{4, 2, 1, 3}, new int[]{4,2}, new int[]{1, 3})]
        public void SplitIntegerArray_ShouldProduceTwoSubArrays(int[] input, int[] expectedLeft, int[] expectedRight)
        {
            AlgorithmsLib al = new AlgorithmsLib();
            int[] resultLeft = new int[]{};
            int[] resultRight = new int[]{};
            al.SplitIntegerArray(input, out resultLeft, out resultRight);

            Assert.True(resultLeft.SequenceEqual(expectedLeft));
            Assert.True(resultRight.SequenceEqual(expectedRight));
        }

        [Theory]
        [InlineData(new int[] { 1, 5}, new int[]{2 ,4, 8}, new int[] {1, 2, 4, 5, 8} )]
        [InlineData(new int[] { 1, 5, 6, 98}, new int[]{2, 4, 8, 10, 11}, new int[] {1, 2, 4, 5, 6, 8, 10, 11, 98} )]
        public void MergeTwoSortedList_ShouldMergeSuccessfull(int[] input1, int[] input2,
            int[] expectedIntegerArray)
        {
            AlgorithmsLib al = new AlgorithmsLib();
            int[] result = al.MergeTwoSortedList(input1, input2);
            Assert.True(result.SequenceEqual(expectedIntegerArray));
        }

        [Theory]
        [InlineData(new int[] { 5,2,76, 1,34}, new int[] { 1, 2,5, 34, 76})]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void MergeSort_ShouldMergeSortSuccessful(int[] input, int[] expected)
        {
            AlgorithmsLib al = new AlgorithmsLib();
            int[] result = al.MergeSort(input);
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 76, 1, 34}, new int[] { 1, 2, 5, 34, 76})]
        [InlineData(new int[] { 2349, 1388, 90, 45221, 4523, 2348, -1, 954}, new int[] { -1, 90, 954, 1388, 2348, 2349, 4523, 45221})]
        [InlineData(new int[] { 5 }, new int[] { 5 })]        
        public void QuickSort_ShouldBeSuccessfully(int[] input, int[] expected)
        {
            AlgorithmsLib al = new AlgorithmsLib();
            al.QuickSort(input, 0, input.Length - 1);
            Assert.True(input.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 76, 1, 34}, 34, 4)]
        [InlineData(new int[] { 2349, 1388, 90, 45221, 4523, 2348, -1, 954}, 90, 2)]
        [InlineData(new int[] { 5 }, 5, 0)]   
        public void BinarySearch_ShouldPass(int[] input, int valueToSearch, int expectedIndex)
        {
            AlgorithmsLib al = new AlgorithmsLib();
            var result = al.BinarySearch(input, valueToSearch);
            Assert.True(result == expectedIndex);  
        }

        [Fact]
        public void AdjacencyMatrix_CanInstantiate()
        {
            AdjacencyMatrixGraph am = new AdjacencyMatrixGraph(3, GraphType.Directed);

            Assert.NotNull(am);
        }
        
        [Fact]
        public void AdjacencyMatrix_addEdge_hasCorrectValue()
        {
            AdjacencyMatrixGraph am = new AdjacencyMatrixGraph(3, GraphType.Directed);
            am.addEdge(1, 2);
            am.addEdge(0, 1);

            Assert.Equal(am.AdjacencyMatrix[1, 2] , 1);
            Assert.Equal(am.AdjacencyMatrix[0, 2] , 0);
        }

        [Fact]
        public void AdjacencyMatrix_addEdte_throwErrorWithIncorrectInputs()
        {
            AdjacencyMatrixGraph am = new AdjacencyMatrixGraph(3, GraphType.Directed);

            Assert.Throws<ArgumentOutOfRangeException>(() => am.addEdge(-1, 0));
        }

        [Fact]
        public void AdjacencyMatrix_listAdjacentVertexes_ShouldBeCorrect()
        {
            AdjacencyMatrixGraph am = new AdjacencyMatrixGraph(5, GraphType.Directed);
            am.addEdge(1, 0);
            am.addEdge(1, 2);
            am.addEdge(1, 3);
            am.addEdge(1, 4);
            List<int> result = am.getAdjacentVertices(1);
            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void AdjacencyMatrix_getInDegree_ShouldMatch()
        {
            AdjacencyMatrixGraph am = new AdjacencyMatrixGraph(5, GraphType.Directed);
            am.addEdge(2, 1);
            am.addEdge(4, 1);
            var expected = am.GetInDegree(1);

            Assert.Equal(expected, 2);
        }

        [Fact]
        public void Graph_TopologicalSort_ShouldOutputCorrectly()
        {
            AdjacencyMatrixGraph amg = new AdjacencyMatrixGraph(5, GraphType.Directed);
            amg.addEdge(0, 1);
            amg.addEdge(0, 2);
            amg.addEdge(1, 3);
            amg.addEdge(3, 2);
            amg.addEdge(3, 4);
            amg.addEdge(2, 4);

            var expected = new int[]{0, 1, 3, 2, 4};

            AlgorithmsLib a = new AlgorithmsLib();
            var results = a.Graph_TopologicalSort(amg);

            Assert.True(results.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(30, "fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke")]
        public void MakeAnagram_ShouldOutputCorrectNumber(
            int expectedDeletedCharacters,
            string a,
            string b
        )
        {
            AlgorithmsLib al = new AlgorithmsLib();
            var result = al.makeAnagram(a, b);
            
            Assert.True(expectedDeletedCharacters == result);
        }

        [Fact]
        public void BTree_BreadthTravelsal_ShouldOutputCorrectly()
        {
            var root = new Node<string>("A");
            root.LeftChild = new Node<string>("B");
            root.RightChild = new Node<string>("C");
            root.LeftChild.LeftChild = new Node<string>("D");
            root.LeftChild.RightChild = new Node<string>("E");
            root.RightChild.LeftChild = new Node<string>("F");
            root.RightChild.RightChild = new Node<string>("G");
            root.LeftChild.LeftChild.LeftChild = new Node<string>("H");
            root.RightChild.LeftChild.LeftChild = new Node<string>("I");
            root.RightChild.RightChild.LeftChild = new Node<string>("J");

            
            var result = Node<string>.BreadthTravelsal(root);
            var resultlist = new List<string>();
            foreach (var e in result)
                resultlist.Add(e.Data);
                
            var expected = new List<string>{"A", "B", "C", "D", 
                                "E", "F", "G", "H", "I", "J"};

            Assert.True(resultlist.SequenceEqual(expected));
        }

        [Fact]
        public void BTree_DepthFirstTravesal_PreOrder_ShouldOutputCorrectly()
        {
            var root = new Node<string>("A");
            root.LeftChild = new Node<string>("B");
            root.RightChild = new Node<string>("C");
            root.LeftChild.LeftChild = new Node<string>("D");
            root.LeftChild.RightChild = new Node<string>("E");
            root.RightChild.LeftChild = new Node<string>("F");
            root.RightChild.RightChild = new Node<string>("G");
            root.LeftChild.LeftChild.LeftChild = new Node<string>("H");
            root.RightChild.LeftChild.LeftChild = new Node<string>("I");
            root.RightChild.RightChild.LeftChild = new Node<string>("J");

            var result = Node<string>.BTree_DepthFirstTravesal_PreOrder(root);
            var expected = new List<string>{"A", "B", "D", "H", 
                                "E", "C", "F", "I", "G", "J"};

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void BST_insert_Input_a_New_Node_ShouldReturnCorrectHeadNodeForInsertedNode()
        {
            var root = new Node<int>(8);
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);

            var expected = root.RightChild.RightChild; // 16
            var result = Node<int>.BST_insert(root, new Node<int>(15));

            Assert.Equal(expected.Data, result.Data);

        }

        [Theory]
        [InlineData(4, true)]
        [InlineData(8, true)]
        [InlineData(7, true)]
        [InlineData(14, true)]
        [InlineData(16, true)]
        [InlineData(18, true)]
        [InlineData(5, false)]
        public void BST_NodeExists_Input_an_Existing_Node_ShouldReturnTrue(
            int input, bool expected)
        {
            var root = new Node<int>(8);
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);

            var result = Node<int>.BST_NodeExists(root, new Node<int>(input));

            Assert.Equal(result, expected);

        }

        [Fact]
        public void BST_findMinNode_shouldReturnMinValueNode()
        {
            var root = new Node<int>(8);    
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);

            var result = Node<int>.BST_findMinNode(root);
            var expected = 4;
            Assert.True(result == expected);
        }

        [Fact]
        public void BST_max_depth_ShouldReturnMax()
        {
            var root = new Node<int>(8);    
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);

            var result = Node<int>.BST_max_depth(root);
            var expected = 3;

            Assert.True(result == expected);
        }
        [Fact]
        public void BST_mirror_ShouldMirrorCorrectly()
        {
            var root = new Node<int>(8);    
            root.LeftChild = new Node<int>(6);
            root.RightChild = new Node<int>(14);
            root.LeftChild.LeftChild = new Node<int>(4);
            root.LeftChild.RightChild = new Node<int>(7);
            root.RightChild.RightChild = new Node<int>(16);
            root.RightChild.RightChild.RightChild = new Node<int>(18);

            var expected = root;
            Node<int>.BST_Mirror(expected);

            Assert.Equal(expected.RightChild.Data, 6);
            Assert.Equal(expected.LeftChild.Data, 14);
            Assert.Equal(expected.LeftChild.LeftChild.Data, 16);
            Assert.Equal(expected.RightChild.LeftChild.Data, 7);


        }
    }
}
