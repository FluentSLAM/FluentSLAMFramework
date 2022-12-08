namespace FluentSLAM.ParticleFilter
{
    public interface IParticleMotionModel<TParticle, TDataEntry> : IMotionModel<IMobileObjectModel, TDataEntry>
        where TParticle : IParticle, IMobileObjectModel
        where TDataEntry : struct
    {
        public void ApplyToSet(IParticleCollection<TParticle> set, TDataEntry data)
        {
            foreach (var particle in set.Particles)
                Apply(particle, data);
        }
    }
}

