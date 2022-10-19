using FluentSLAM.MapModels;
using FluentSLAM.MapModels.GraphModel;
using QuickGraph;

namespace FluentSLAM.Models.GraphEdgePointModel
{
	public class GraphEdgePointModel<TVertex, TEdge, TGraph, TCoord> : GraphMapModel<TVertex, TEdge, TGraph>
        where TVertex : notnull
        where TEdge : IEdge<TVertex>
        where TGraph : IUndirectedGraph<TVertex, TEdge>, IMutableVertexAndEdgeSet<TVertex, TEdge>, new()
    {
		public GraphEdgePointModel() : base()
        {
        }

        public GraphEdgePointModel(List<TEdge> edgeList) : base(edgeList)
        {
        }

        public double GetDistanceBetweenPoints(
            EdgePoint<TEdge, double> p1,
            EdgePoint<TEdge, double> p2)
        {
            if (p1.Edge.Equals(p2.Edge))
                return Math.Abs(p1.Coord - p2.Coord);

            var v1 = p1.Edge.Source;
            var v2 = p1.Edge.Target;
            var v3 = p2.Edge.Source;
            var v4 = p2.Edge.Target;

            var dv1v3 = GetDistanceBetweenVertices(v1, v3);
            var dv1v4 = GetDistanceBetweenVertices(v1, v4);
            var dv2v3 = GetDistanceBetweenVertices(v2, v3);
            var dv2v4 = GetDistanceBetweenVertices(v2, v4);

            var path1 = p1.Coord + dv1v3 + p2.Coord;
            var path2 = p1.Coord + dv1v4 + _edgeWeights[p2.Edge] - p2.Coord;
            var path3 = _edgeWeights[p1.Edge] - p1.Coord + dv2v3 + p2.Coord;
            var path4 = _edgeWeights[p1.Edge] - p1.Coord + dv2v4 + _edgeWeights[p2.Edge] - p2.Coord;

            return new double[] { path1, path2, path3, path4 }.Min();
        }
    }
}

