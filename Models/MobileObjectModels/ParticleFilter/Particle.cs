namespace FluentSLAM.Models.MobileObjectModels.ParticleFilter
{
	public class Particle<TPosition> : IMobileObjectModel
	{
		public TPosition Position { get;  set; }

		public Particle(TPosition initialPosition)
		{
			Position = initialPosition;
		}
	}
}

