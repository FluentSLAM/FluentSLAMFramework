namespace FluentSLAM.MapModels
{
    public interface IGrid<TCell> : IMapModel
    {
        public TCell Sum();
        public TCell Average();
        public void Normalize();
    }
}