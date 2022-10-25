namespace FluentSLAM.MapModels
{
	public class MarginGrid1D<TCell> : Grid1D<TCell>
	{
		public int Margin { get; private set; }

		public override TCell this[int i]
		{
			get
			{
				if (i >= Margin)
					throw new IndexOutOfRangeException("Index should be lower than margin.");
				return _cells[i];
            }
			set
			{
				if(i >= Margin)
                    throw new IndexOutOfRangeException("Index should be lower than margin.");
                _cells[i] = value;
            }
		}
		
		public MarginGrid1D(int size, int margin) : base(size)
		{
			if (margin > size)
				throw new IndexOutOfRangeException("Margin should not be greater than grid size.");

			Margin = margin;
		}

		public bool Resize(int newMargin)
		{
			if (newMargin < 0)
				throw new IndexOutOfRangeException("Margin should be 0 or greater.");

			if (newMargin == Margin)
				return false;

            Margin = newMargin;

            if (newMargin < Margin)
				return false;

			var newCells = new TCell[Margin];
			for (var i = 1; i < _cells.Length; i++)
				newCells[i] = _cells[i];
			return true;
		}
	}
}

