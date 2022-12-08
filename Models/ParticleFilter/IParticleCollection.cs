namespace FluentSLAM.ParticleFilter
{
    public interface IParticleCollection<TParticle> : IMobileObjectModel
        where TParticle : IParticle
    {
        public ICollection<TParticle> Particles { get; }

        public void NormalizeWeights()
        {
            double sum = 0;
            foreach (var particle in Particles)
                sum += particle.Weight;

            foreach (var particle in Particles)
                particle.Weight /= sum;
        }
    }
}

