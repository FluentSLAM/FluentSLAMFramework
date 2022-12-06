namespace FluentSLAM.ParticleFilter
{
    public interface IParticleSet<TParticle> : IMobileObjectModel
        where TParticle : IParticle
    {
        public ICollection<TParticle> Particles { get; set; }

        public void NormalizeWeights();
    }
}

