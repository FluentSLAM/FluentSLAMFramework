namespace FluentSLAM.ParticleFilter
{
    public abstract class ParticleCollectionMotionModel<TParticle, TDataEntry> : IMotionModel<IParticleCollection<TParticle>, TDataEntry>
        where TParticle : IParticle, IMobileObjectModel
        where TDataEntry : struct
    {
        public void Apply(IParticleCollection<TParticle> set, TDataEntry data)
        {
            foreach (var particle in set.Particles)
                ApplyToParticle(particle, data);
        }

        public virtual void ApplyToParticle(TParticle particle, TDataEntry data)
        {
            throw new NotImplementedException();
        }
    }
}

