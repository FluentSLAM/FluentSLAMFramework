namespace FluentSLAM.ParticleFilter
{
    public abstract class ParticleCollectionMotionModel<TParticle, TDataEntry> : IMotionModel<IParticleCollection<TParticle>, TDataEntry>
        where TParticle : IParticle, IMobileObjectModel
        where TDataEntry : struct
    {
        public void Apply(IParticleCollection<TParticle> collection, TDataEntry data)
        {
            Parallel.ForEach(collection.Particles, particle =>
            {
                ApplyToParticle(particle, data);
            });
        }

        public virtual void ApplyToParticle(TParticle particle, TDataEntry data)
        {
            throw new NotImplementedException();
        }
    }
}

