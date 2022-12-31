namespace FluentSLAM.ParticleFilter
{
    public interface IParticleProvider<TParticle> where TParticle : IParticle
    {
        public TParticle GetParticle();
    }
}