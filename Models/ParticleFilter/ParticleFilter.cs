using FluentSLAM.ParticleFilter;

namespace FluentSLAM
{
	public class ParticleFilter<TParticle, TMap> : FluentModel<IParticleCollection<TParticle>, TMap>
        where TParticle : IParticle, IMobileObjectModel, new()
        where TMap : IMapModel
	{
        public ParticleFilter(IParticleCollection<TParticle> mobileObject, TMap map, int number) : base(mobileObject, map)
        {
            mobileObject.InitParticles(number);
        }

        protected override void ApplyMotionModel<TDataEntry>(
            IMotionModel<IParticleCollection<TParticle>, TDataEntry> model,
            TDataEntry data)
        {
            // TODO: parallel computing
            model.Apply(MobileObject, data);
        }

        protected override void ApplyObservationModel<TDataEntry>(
            IObservationModel<TMap, TDataEntry> model,
            TDataEntry data)
        {
            model.Apply(Map, data);
            RecalculateWeights();
        }

        protected virtual void RecalculateWeights()
        {
            throw new NotImplementedException();
        }

        public virtual ParticleFilter<TParticle, TMap> Resample()
        {
            throw new NotImplementedException();
        }
    }
}

