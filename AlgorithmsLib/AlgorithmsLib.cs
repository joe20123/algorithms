using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsLibrary
{
    public class AlgorithmsLib
    {
        //Q1
        public int sum(int num) {
            if ( num == 0) 
                return 0;
            return num % 10 + sum(num / 10);
        }

        //Q2
        public int isArmstrongNumber(int num) {
            return cubeSum(num);
        }

        public int cubeSum(int num) {
            if (num == 0) return 0;
            return Convert.ToInt32(Math.Pow(num % 10, 3) ) + cubeSum(num / 10);
        }

        //Q3
        public bool isPalindrome(string input) {
            int min = 0;
            int max = input.Length - 1;
            while(true) {
                if (min > max)
                    return true;
                char a = input[min];
                char b = input[max];
                if (char.ToLower(a) != char.ToLower(b)){
                    return false;
                }
                min++;
                max--;
            }
        }

        //Q4
        public string RemoveDuplicatesInString(string input){
            if(String.IsNullOrEmpty(input)) return null;

            char[] a = new char[input.Length];
            int c = 0;
            for (int i = 0; i < input.Length; i++){
                char current =input[i];
                bool found = false;
                foreach(char j in a){
                    if(j == current){
                        found = true;
                        break;
                    }
                }
                if(!found){
                    a[c] = current;
                    c++;
                }
            }
            string newstring = "";
            foreach(char i in a){               
                newstring += i;
            }
            return newstring.Trim();
        }

        public string RemoveDuplicatesInString_v2(string input) {

            string result = "";

            foreach(char i in input) {
                if (result.IndexOf(i) == -1)
                    result += i;
            }
            return result;
        }

        //Q5
        public bool areTheyAnagrams(string a1, string a2) {
            if ( String.IsNullOrEmpty(a1) || String.IsNullOrEmpty(a2))
                return false;
            
            if (a1.Length != a2.Length)
                return false;

            while(a1.Length >= 1){
                int location = a2.IndexOf(a1[0]);
                if (location == -1)
                    return false;
                if(a1.Length == 1)
                    return true;
                a1 = a1.Remove(0, 1);
                a2 = a2.Remove(location, 1);
            }

            return true;

        }

        //Q6: is number a prime number      
        public bool isPrime(int input){
            if (input <= 1) return false;
            int counter = 2;
            while (counter < input){
                if(input % counter == 0)
                    return false;
                counter++;
            }
            return true;
        }

        //Q7: selection sort. in place sort. not adaptive. not stable
        public int[] selectionSort (int[] input)
        {
            if (input == null)
                return null;
            if (input.Length == 1)
                return input;
           
            for (var k = 0; k < input.Length; k++)
            {              
                for (var i = k + 1; i < input.Length; i++)
                {
                    if (input[i] < input[k])
                    {
                        int temp = input[k];
                        input[k] = input[i];
                        input[i] = temp;
                        break;
                    }
                }   
            }
            return input;
        }
        

        // Q8: Bubble sort. O(N^2). stable sort. adaptive. in-place sort
        public int[] BubbleSort (int[] input)
        {
            if (input == null || input.Length == 0) return null;

            while (true)
            {
                int swapCount = 0;
                for (var i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        (input[i], input[i + 1]) = (input[i+1], input[i]);
                        swapCount++;
                    }
                }
                if (swapCount == 0)
                    return input;
            }           
        }

        // Q9: insertion sort. O(N^2). Adaptive. Sort in place.
        public int[] InsertionSort (int[] input)
        {
            if (input == null) return null;

            for (var i = 0; i < input.Length - 1; i++)
            {
                for (var j = i + 1; j > 0; j--)
                {
                    if (input[j] < input[j - 1])
                    {
                        (input[j], input[j - 1]) = (input[j - 1], input[j]);
                    } else 
                    {
                        break;
                    }
                }
            }  
            return input;
        }
        
        public int[] InsersionSort_V2(int[] input, int startIndex, int increment)
        {
            if (input == null) return null;
            if (startIndex < 0 || startIndex > input.Length - 1) return input;
            if (increment <= 0 || increment > input.Length -1) return input;

            for (var i = startIndex; i < input.Length; i = i + increment)
            {
                for (var j = Math.Min(i + increment, input.Length - 1); 
                    j - increment >= 0; 
                    j = j - increment)
                {
                    if (input[j] < input[j - increment])
                    {
                        (input[j], input[j - increment]) = (input[j - increment], input[j]);
                    } else 
                    {
                        break;
                    }
                }                
            }
            return input;
            
        }

        // Q10: Shell Sort. between O(N) and O(N^2). sort in place. adaptive.
        public int[] ShellSort (int[] input, int increment) 
        {
            if (input == null) return null;
            if (input.Length == 1) return input;
            if (increment <= 0) return input;

            for (var i = 0; i < increment; i++)
            {
                input = InsersionSort_V2 (input, i, increment);
            }
            return input = InsersionSort_V2 (input, 0, 1);
        }

        // Q11: Merge Sort. The order is O(NLogN)
        public void SplitIntegerArray (int[] input, out int[] output1, out int[] output2)
        {
            if (input == null) 
            {
                output1 = null;
                output2 = null;
                return;
            }
            if (input.Length == 1)
            {
                output1 = null;
                output2 = null;
                return;
            }

            int splitLeftNo = (input.Length % 2 == 0) ? input.Length / 2 : input.Length /2 + 1;

            output1 = new int[splitLeftNo];
            output2 = new int[input.Length - splitLeftNo];

            for (var i = 0; i < input.Length; i++)
            {
                if (i < splitLeftNo)
                {
                    output1[i] = input[i];
                } else {
                    output2[i - splitLeftNo] = input[i];
                }
            }
        }

        public int[] MergeTwoSortedList(int[] input1, int[] input2)
        {
            if (input1 == null && input2 == null) return null;
            if (input1 == null) return input2;
            if (input2 == null) return input1;

            int count = 0;
            int[] output = new int[input1.Length + input2.Length];
            
            int input1Index = 0;
            int input2Index = 0;
            while (input1Index < input1.Length && input2Index < input2.Length)
            {
                if (input1[input1Index] < input2[input2Index])
                {
                    output[count] = input1[input1Index];
                    input1Index++;
                } else if (input2Index < input2.Length) 
                {
                    output[count] = input2[input2Index];
                    input2Index++;
                }
                count++;
            }
            if (input1Index < input1.Length)
            {
                while (count < output.Length)
                {
                    output[count++] = input1[input1Index++];
                }
            }
            if (input2Index < input2.Length)
            {
                while (count < output.Length)
                {
                    output[count++] = input2[input2Index++];
                }
            }
            return output;
        }

        public int[] MergeSort(int[] input)
        {
            if (input == null) return null;
            if (input.Length == 1) return input;

            int midPointIndex = input.Length /2 + input.Length % 2;
            int[] leftArray = new int[]{};
            int[] rightArray = new int[]{};
            SplitIntegerArray(input, out leftArray, out rightArray);

            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            return MergeTwoSortedList(leftArray, rightArray);
        }

        // Q12: Quick sort
        // (low, high) are the array 
        public int Partition(int[] input, int low, int high)
        {
            if (input == null) return -1;
            int pivot = input[low];
            int l = low;
            int h = high;

            while (l < h)
            {
                while (input[l] <= pivot && l < h)
                {
                    l++;
                }
                while (input[h] > pivot)
                {
                    h--;
                }
                if (l < h)
                {
                    (input[l], input[h]) = (input[h], input[l]);
                }
            }
            (input[low], input[h]) = (input[h], input[low]);

            return h;
        }

        public void QuickSort(int[] input, int left, int right)
        {
            if (left > right)
                return;
            int pivotIndex = Partition(input, left, right);
            QuickSort(input, left, pivotIndex - 1);
            QuickSort(input, pivotIndex + 1, right);
        }
        
        // Q13: Binary Search. O(LogN)
        public int BinarySearch(int[] input, int number)
        {
            if (input == null) return -1;
            
            int low = 0;
            int high = input.Length - 1;

            while(low <= high)
            {
                var mid = (low + high) / 2 + low;
                if (input[mid] == number)
                {
                    return mid;
                }
                if (input[mid] > number)
                    high--;
                if (input[mid] < number)
                    low++;
            }
            return -1;
        }

        // Q14: Topological Sort for Graph
        public int[] Graph_TopologicalSort(AdjacencyMatrixGraph graph)
        {
            int numbers = graph.numVertices;
            var q = new Queue<int>();

            while (q.Count < numbers)
            {
                for (var i = 0; i < numbers; i++)
                {
                    if (q.Contains(i))
                        continue;

                    if (graph.GetInDegree(i) == 0)
                    {
                        q.Enqueue(i);
                        var neighbours = graph.getAdjacentVertices(i);
                        // remove edges starting from vertice i
                        foreach (var j in neighbours)
                        {
                            graph.AdjacencyMatrix[i, j] = 0;
                        }
                    }    
                }
            }
            if (q.Count != numbers)
                throw new Exception("Error: input graph matrix is not acyclic.");

            return q.ToArray();
        }


        // Q15:
        public int makeAnagram(string a, string b) 
        {

            string start = a;
            string end = b;
            string end_origin = b;
            if (a.Length > b.Length)
            {
                start = b;
                end = a;
                end_origin = a;
            }
        
            var anagram = "";       
            foreach (var i in start)
            {
                var index = -1;
                foreach (var j in end)
                {
                    index += 1;
                    if (i == j)
                    {
                        anagram += i;
                        end = end.Remove(index, 1);
                        
                        break;
                    }
                }            
            }
            return (start.Length - anagram.Length + end_origin.Length - anagram.Length);

        }



    }


}