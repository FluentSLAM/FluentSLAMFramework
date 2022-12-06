namespace FluentSLAM.MobileObjectModels.ParticleFilter
{
	public class ParticleSet<TParticle> : IParticleSet<TParticle>
        where TParticle : IParticle
    {
        public ICollection<TParticle> Particles { get; set; }

        protected IParticleProvider<TParticle> _particleProvider;

        public ParticleSet(IParticleProvider<TParticle> particleProvider)
		{
            _particleProvider = particleProvider;
		}

        public void NormalizeWeights()
        {
            throw new NotImplementedException();
        }
    }
}

