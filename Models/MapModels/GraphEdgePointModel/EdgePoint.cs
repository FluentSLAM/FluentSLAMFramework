using System;
namespace FluentSLAM.MapModels.GraphModel
{
	public class EdgePoint<TEdge, TCoord>
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

