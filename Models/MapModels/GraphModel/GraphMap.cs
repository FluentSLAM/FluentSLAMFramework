using NGenerics.DataStructures.General;

namespace FluentSLAM.MapModels
{
	public class GraphMap<TVertexData> : MapModel
	{
		public Graph<TVertexData> Graph { get; private set; }

		public GraphMap(bool isDirected)
		{
			Graph = new Graph<TVertexData>(isDirected);
		}
	}
}

