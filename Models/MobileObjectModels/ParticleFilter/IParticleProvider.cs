namespace FluentSLAM.MobileObjectModels.ParticleFilter
{
	public interface IParticleProvider<TParticle> where TParticle : IParticle
    {
		public IParticle GetParticle();
	}
}

