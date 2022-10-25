namespace FluentSLAM.MapModels
{
	public class Grid3D<TCell> : IMapModel
	{
        protected TCell[,,] _cells;

        public TCell this[int i, int j, int k]
        {
            get
            {
                return _cells[i, j, k];
            }
            set
            {
                _cells[i, j, k] = value;
            }
        }

        public Grid3D(int height, int width, int depth)
        {
            _cells = new TCell[height, width, depth];
        }
    }
}

