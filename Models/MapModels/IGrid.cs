using System;
namespace FluentSLAM.MapModels
{
	public interface IGrid<TCell>
	{
		public TCell Average();
		public void Normalize();
	}
}

