namespace FluentSLAM.Models.MobileObjectModels.ParticleFilter
{
	public class Particle<TPosition> : IMobileObjectModel<TPosition>
	{
        public TPosition? Position { get; set; }

        public Particle()
		{
			Position = default(TPosition);
		}

		public Particle(TPosition initialPosition)
		{
			Position = initialPosition;
		}
	}
}

