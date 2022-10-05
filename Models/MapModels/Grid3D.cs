namespace FluentSLAM.MapModels
{
	public class Grid3D<TCell> : MapModel
	{
        protected TCell[,,] Cells { get; private set; }

        public Grid3D(int height, int width, int depth)
        {
            Cells = new TCell[height, width, depth];
        }
    }
}

