using System.Numerics;

namespace FluentSLAM.MapModels.GraphModel
{
    public struct EdgePoint<TEdge, TCoord>
        where TCoord : INumber<TCoord>
    {
        public TEdge Edge { get; private set; }
        public TCoord Coord { get; private set; }

        public EdgePoint(TEdge edge, TCoord coord)
        {
            Edge = edge;
            Coord = coord;
        }
    }
}