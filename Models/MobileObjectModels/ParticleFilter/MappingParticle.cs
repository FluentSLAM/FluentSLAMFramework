namespace FluentSLAM.Models.MobileObjectModels.ParticleFilter
{
	public class MappingParticle<TPosition, TMap> : Particle<TPosition>
		where TMap : IMapModel, new()
	{
		public TMap Map { get; set; }

		public MappingParticle(TPosition initialPosition) : base (initialPosition)
		{
		}

		public void InitializeMap()
		{
			Map = new TMap();
		}
	}
}

