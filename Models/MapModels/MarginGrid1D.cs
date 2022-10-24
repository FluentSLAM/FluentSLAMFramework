namespace FluentSLAM.MapModels
{
	public class MarginGrid1D<TCell> : Grid1D<TCell>
	{
		public int Margin { get; private set; }

		public TCell this[int i]
		{
			get
			{
				if (i >= Margin)
					throw new IndexOutOfRangeException("Index should be lower than margin.");
				return _cells[i];
            }
			set { }
		}
		
		public MarginGrid1D(int size, int margin) : base(size)
		{
			if (margin > size)
				throw new IndexOutOfRangeException("Margin should not be greater than grid size.");

			Margin = margin;
		}
	}
}

