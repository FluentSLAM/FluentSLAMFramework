namespace FluentSLAM.MapModels
{
	public class MultiGrid<TKey, TGrid, TCell> : IGrid<TCell>
		where TGrid : IGrid<TCell>
		where TKey : notnull
	{
		private Dictionary<TKey, TGrid> _grid;

		public TGrid this[TKey key]
		{
			get
			{
				return _grid[key];
			}

			set
			{
				_grid[key] = value;
			}
		}

        public MultiGrid()
		{
			_grid = new Dictionary<TKey, TGrid>();
		}

		public TCell Sum()
		{
            throw new NotImplementedException();
        }

		public TCell Average()
		{
			throw new NotImplementedException();
		}

		public void Normalize()
		{
			throw new NotImplementedException();
		}
	}
}
