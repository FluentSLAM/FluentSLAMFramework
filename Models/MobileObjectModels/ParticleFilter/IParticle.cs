namespace FluentSLAM.MobileObjectModels.ParticleFilter
{
	public interface IParticle<TPosition> : IMobileObjectModel<TPosition>
	{
		public double Weight { get; }
	}
}

