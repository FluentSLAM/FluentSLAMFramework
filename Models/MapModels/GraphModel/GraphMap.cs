using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using FluentSLAM.Misc;

using FluentSLAM.MapModels.GraphModel;

namespace FluentSLAM.MapModels
{
	public class GraphMap<TVertex, TEdge> : MapModel
		where TVertex : notnull
		where TEdge : IEdge<TVertex>
	{
		public IMutableUndirectedGraph<TVertex, TEdge> Graph { get; private set; }

		private Dictionary<TEdge, double> _edgeWeights = new Dictionary<TEdge, double>();


        private Dictionary<TVertex, int> _vertexIndex;
		private double[,] _distanceMatrix;

		public GraphMap()
		{
			Graph = new UndirectedGraph<TVertex, TEdge>();
		}

        public GraphMap(List<TEdge> edgeList)
        {
            Graph = new UndirectedGraph<TVertex, TEdge>();

			foreach (var edge in edgeList)
				Graph.AddVerticesAndEdge(edge);

			CalculateVerticesIndex();
			CalculateDistanceMatrix();
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
                var PathTryFunc = AlgorithmExtensions.ShortestPathsDijkstra<TVertex, TEdge>(Graph, (edge) => _edgeWeights[edge], v);

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
			throw new NotImplementedException();
		}

		public double GetDistanceBetweenPoints(
			EdgePoint<Edge<Vertex>, double> firstPoint,
			EdgePoint<Edge<Vertex>, double> secondPoint)
		{
			throw new NotImplementedException();
		}
	}
}

