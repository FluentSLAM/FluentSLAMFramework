namespace FluentSLAM.MobileObjectModels
{
	public class MobileObject1D<TPosition> : IMobileObjectModel<TPosition>
	{
		public TPosition? Position { get; set; }

		public MobileObject1D(TPosition initialPosition)
		{
			Position = initialPosition;
		}
	}
}

