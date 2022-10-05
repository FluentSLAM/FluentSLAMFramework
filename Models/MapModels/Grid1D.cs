namespace FluentSLAM.Models.MapModels
{
	public class Grid1D<TCell> : MapModel
	{
		protected TCell[] Cells { get; private set; }

		public Grid1D(int size)
		{
			Cells = new TCell[size];
		}
	}
}

