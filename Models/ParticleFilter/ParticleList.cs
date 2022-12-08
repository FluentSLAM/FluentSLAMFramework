namespace FluentSLAM.ParticleFilter
{
	public class ParticleList<TParticle> : IParticleCollection<TParticle>
        where TParticle : IParticle
    {
        public ICollection<TParticle> Particles { get; private set; } = new List<TParticle>();

        protected IParticleProvider<TParticle> _particleProvider;

        public ParticleList(IParticleProvider<TParticle> particleProvider)
		{
            _particleProvider = particleProvider;
            InitParticles(0);
		}

        public ParticleList(IParticleProvider<TParticle> particleProvider, int number)
        {
            _particleProvider = particleProvider;
            InitParticles(number);
        }

        private void InitParticles(int number)
        {
            Particles = new List<TParticle>(number);

            for (int i = 0; i < number; i++)
            {
                var particle = _particleProvider.GetParticle();
                particle.Weight = 1 / number;
                Particles.Add(particle);
            }
        }
    }
}

