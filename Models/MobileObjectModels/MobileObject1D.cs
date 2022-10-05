namespace FluentSLAM.MobileObjectModels
{
	public class MobileObject1D<TPos> : MobileObjectModel
	{
		protected TPos Position { get; set; }

		public MobileObject1D(TPos initialPosition)
		{
			Position = initialPosition;
		}
	}
}

