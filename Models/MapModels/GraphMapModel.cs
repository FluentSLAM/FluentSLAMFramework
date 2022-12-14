using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using FluentSLAM.Misc;

namespace FluentSLAM.MapModels
{
    public class GraphMapModel<TVertex, TEdge, TGraph> : IMapModel
        where TVertex : notnull
        where TEdge : IEdge<TVertex>
        where TGraph : IUndirectedGraph<TVertex, TEdge>, IMutableVertexAndEdgeSet<TVertex, TEdge>, new()
    {
        public TGraph Graph { get; private set; }
        public bool IsDistanceMatrixUpdated { get; private set; } = false;

        protected Dictionary<TEdge, double> _edgeWeights = new Dictionary<TEdge, double>();
        private Dictionary<TVertex, int> _vertexIndex = new Dictionary<TVertex, int>();
        private double[,] _distanceMatrix;

        public GraphMapModel()
        {
            ResetGraph();
        }

        public GraphMapModel(List<TEdge> edgeList)
        {
            ResetGraph();
            LoadEdges(edgeList);
            UpdateDistanceMatrix();
        }

        public GraphMapModel(List<TEdge> edgeList, List<double> weights)
        {
            ResetGraph();
            LoadEdges(edgeList, weights);
            UpdateDistanceMatrix();
        }

        public void ResetGraph()
        {
            Graph = new TGraph();
            IsDistanceMatrixUpdated = false;
        }

        public void LoadEdges(List<TEdge> edgeList)
        {
            _edgeWeights = new Dictionary<TEdge, double>(edgeList.Count);
            foreach (var edge in edgeList)
            {
                Graph.AddVerticesAndEdge(edge);
                _edgeWeights.Add(edge, 1);
            }

            IsDistanceMatrixUpdated = false;
        }

        public void LoadEdges(List<TEdge> edgeList, List<double> weights)
        {
            _edgeWeights = new Dictionary<TEdge, double>(edgeList.Count);
            foreach (var (edge, weight) in edgeList.Zip(weights))
            {
                Graph.AddVerticesAndEdge(edge);
                _edgeWeights.Add(edge, weight);
            }

            IsDistanceMatrixUpdated = false;
        }

        public void UpdateDistanceMatrix()
        {
            CalculateVerticesIndex();
            CalculateDistanceMatrix();
            IsDistanceMatrixUpdated = true;
        }

        private void CalculateVerticesIndex()
        {
            _vertexIndex = new Dictionary<TVertex, int>();
            foreach (var (vertex, index) in Graph.Vertices.WithIndex())
                _vertexIndex.Add(vertex, index);
        }

        private void CalculateDistanceMatrix()
        {
            _distanceMatrix = new double[_vertexIndex.Count, _vertexIndex.Count];

            foreach (var v in Graph.Vertices)
            {
                var PathTryFunc =
                    AlgorithmExtensions.ShortestPathsDijkstra<TVertex, TEdge>(Graph, (edge) => _edgeWeights[edge], v);

                foreach (var u in Graph.Vertices)
                {
                    IEnumerable<TEdge> result;
                    PathTryFunc(u, out result);
                    _distanceMatrix[_vertexIndex[v], _vertexIndex[u]] = result.Sum(e => _edgeWeights[e]);
                }
            }
        }

        public double GetDistanceBetweenVertices(TVertex source, TVertex target)
        {
            if (!IsDistanceMatrixUpdated)
                UpdateDistanceMatrix();
            return _distanceMatrix[_vertexIndex[source], _vertexIndex[target]];
        }
    }
}