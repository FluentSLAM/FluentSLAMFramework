namespace FluentSLAM.MapModels.GraphModel
{
	public class EdgeGrid1D<TCell, TEdge> : Grid1D<TCell>
	{
		public TEdge Edge { get; private set; }

		public EdgeGrid1D(TEdge edge, int size) : base(size) 
		{
			Edge = edge;
		}
	}
}
