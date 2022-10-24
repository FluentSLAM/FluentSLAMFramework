namespace FluentSLAM.MapModels
{
	public class Grid1D<TCell> : IMapModel
	{
		protected TCell[] _cells;

		public TCell this[int i]
		{
			get
			{
				return _cells[i];
			}
			set
			{
				_cells[i] = value;
			}
		}

		public Grid1D(int size)
		{
			_cells = new TCell[size];
		}
	}
}

