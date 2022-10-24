namespace FluentSLAM.MobileObjectModels
{
	public class MobileObject1D<TPoint> : IMobileObjectModel
	{
		protected TPoint Position { get; set; }

		public MobileObject1D(TPoint initialPosition)
		{
			Position = initialPosition;
		}
	}
}

