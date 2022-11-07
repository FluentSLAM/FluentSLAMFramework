namespace FluentSLAM.MapModels
{
	public interface IGrid<TCell>
	{
		public TCell Sum();
		public TCell Average();
		public void Normalize();
	}
}

