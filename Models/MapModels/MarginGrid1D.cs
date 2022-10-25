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

		public bool Copy(Grid1D<TCell> cells)
		{
			Margin = cells.Length;
			var resized = false;

            if (Margin > _cells.Length)
            {
				_cells = new TCell[cells.Length];
				resized = true;
            }

			for (var i = 0; i < cells.Length; i++)
				_cells[i] = cells[i];
			return resized;
		}

		public bool Resize(int newMargin)
		{
			if (newMargin < 0)
				throw new IndexOutOfRangeException("Margin should be 0 or greater.");

            Margin = newMargin;

			if (newMargin > _cells.Length)
			{
				var newCells = new TCell[Margin];
				for (var i = 0; i < _cells.Length; i++)
					newCells[i] = _cells[i];
				_cells = newCells;
                return true;
            }

			return false;
		}
	}
}

