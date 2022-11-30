using FluentSLAM.MobileObjectModels.ParticleFilter;

namespace FluentSLAM.Models.SLAMModel
{
	public class ParticleFilter<TParticle, TPosition, TMap> : FluentModel<IParticle<TPosition>, TMap>
        where TParticle : IParticle<TPosition>
        where TMap : IMapModel
	{
        protected TParticle[] Particles { get; private set; }

        public ParticleFilter()
		{
            InitializeParticles();
		}

        private void InitializeParticles()
        {
            throw new NotImplementedException();
        }

        protected override void ApplyMotionModel<TMotionModel, TDataEntry>(
            TMotionModel model,
            TDataEntry data)
        {
            foreach (var particle in Particles)
                model.Apply(particle, data);
        }

        protected override void ApplyObservationModel<TObservationModel, TDataEntry>(
            TObservationModel model,
            TDataEntry data)
        {
            model.Apply(Map, data);
            RecalculateWeights();
        }

        protected virtual void RecalculateWeights()
        {
            throw new NotImplementedException();
        }

        public virtual ParticleFilter<TParticle, TPosition, TMap> Resample()
        {
            throw new NotImplementedException();
        }
    }
}

