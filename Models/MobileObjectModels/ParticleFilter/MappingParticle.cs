namespace FluentSLAM.Models.MobileObjectModels.ParticleFilter
{
	public class MappingParticle<TPosition, TMap> : Particle<TPosition>
		where TMap : IMapModel, new()
	{
		public TMap? Map { get; set; }

		public MappingParticle() : base()
		{
			Map = default(TMap);
		}

		public MappingParticle(TPosition initialPosition) : base(initialPosition)
		{
		}

		public MappingParticle(TPosition initialPosition, TMap initialMap) : base(initialPosition)
		{
			Map = initialMap;
		}

		public override void Reset()
		{
			base.Reset();

			Map = default(TMap); // TODO: map smart reset
		}
	}
}

