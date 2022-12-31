namespace FluentSLAM.MapModels
{
    public class Grid2D<TCell> : IMapModel
    {
        protected TCell[,] _cells;

        public TCell this[int i, int j]
        {
            get { return _cells[i, j]; }
            set { _cells[i, j] = value; }
        }

        public Grid2D(int height, int width)
        {
            _cells = new TCell[height, width];
        }
    }
}