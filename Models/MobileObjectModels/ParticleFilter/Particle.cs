﻿using FluentSLAM.Misc.ObjectPool;

namespace FluentSLAM.Models.MobileObjectModels.ParticleFilter
{
	public class Particle<TPosition> : IMobileObjectModel<TPosition>, IPoolable
	{
        public TPosition? Position { get; set; }

		public double Weight { get; set; }

        public Particle()
		{
			Position = default(TPosition);
		}

		public Particle(TPosition initialPosition)
		{
			Position = initialPosition;
		}

		public virtual void Reset()
		{
			Weight = 0.0;
			Position = default(TPosition); // TODO: reset position fields?
		}
	}
}

