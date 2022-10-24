namespace FluentSLAM
{
    public interface ICorrectionModel<TDataEntry> where TDataEntry : struct
    {
        public void Apply(IMapModel map, TDataEntry data);
    }
}
