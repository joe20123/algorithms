using System;
using System.Collections.Generic;

namespace AlgorithmsLibrary
{
    public class AdjacencyMatrixGraph : IGraph
    {
        public GraphType Type { get; set; }
        public int numVertices { get; set; }
        public int[,] AdjacencyMatrix { get; set; }

        public AdjacencyMatrixGraph(int numVertices, GraphType gt)
        {
            this.Type = gt;
            this.numVertices = numVertices;
            this.AdjacencyMatrix = new int[numVertices, numVertices];

            for (var i = 0; i < numVertices; i++)
            {
                for (var j = 0; j < numVertices; j++)
                {
                    AdjacencyMatrix[i, j] = 0;
                }
            }
        }

        public void addEdge(int v1, int v2)
        {
            if (v1 >= numVertices || v1 < 0 || v2 >= numVertices || v2 < 0)
            {
                throw new ArgumentOutOfRangeException("Vertice number is not valid.");
            }
            AdjacencyMatrix[v1, v2] = 1;
            if (this.Type == GraphType.unDirected )
                AdjacencyMatrix[v2, v1] = 1;
        }

        public List<int> getAdjacentVertices(int v)
        {
            if (v >= numVertices || v < 0)
                throw new ArgumentOutOfRangeException("Vertice number is not valid.");
                
            var list = new List<int>();
            for (var i = 0; i < numVertices; i++)
            {
                if (this.AdjacencyMatrix[v, i] == 1)
                    list.Add(i);
            }
            return list;
        }

        public int GetInDegree(int v)
        {
            if (v < 0 || v >= numVertices)
                throw new ArgumentOutOfRangeException("vertice number is out of range.");

            var count = 0;
            for (var i = 0; i < numVertices; i++)
            {
                if (i == v) continue;

                if (AdjacencyMatrix[i, v] == 1)
                    count++;
            }
            return count;
        }
    }
}