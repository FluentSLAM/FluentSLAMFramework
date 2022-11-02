using System.Numerics;

namespace FluentSLAM.MapModels
{
	public class Grid1D<TCell> : IMapModel, IGrid<TCell>
		where TCell : INumber<TCell>
	{
		protected TCell[] _cells;

		public int Length {
			get
			{
				return _cells.Length;
			}
		}

		public virtual TCell this[int i]
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

		public TCell Average()
		{
			var average = TCell.CreateChecked(0);

			foreach (var cell in _cells)
				average += cell;

			return average /= TCell.CreateChecked(_cells.Length);
		}

		public void Normalize()
		{
			var average = Average();

			for (var i = 0; i < _cells.Length; i++)
				_cells[i] /= average;
		}
    }
}

