namespace FluentSLAM.MobileObjectModels
{
	public class MobileObject1D<TPoint> : MobileObjectModel
	{
		protected TPoint Position { get; set; }

		public MobileObject1D(TPoint initialPosition)
		{
			Position = initialPosition;
		}
	}
}

