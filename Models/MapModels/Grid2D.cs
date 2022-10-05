namespace FluentSLAM.MapModels
{
	public class Grid2D<TCell> : MapModel
    {
        protected TCell[,] Cells { get; private set; }

        public Grid2D(int height, int width)
		{
			Cells = new TCell[height, width];
		}
	}
}

