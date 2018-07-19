using System.Collections.Generic;

namespace AlgorithmsLibGraph
{
    public interface IGraph
    {
        int[,] AdjacencyMatrix { get; set; }
        int numVertices { get; set; }
        GraphType Type { get; set; }
        void addEdge(int v1, int v2);
        List<int> getAdjacentVertices(int v);
    }


}