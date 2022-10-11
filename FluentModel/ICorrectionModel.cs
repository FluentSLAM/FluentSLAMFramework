namespace FluentSLAM
{
    public interface ICorrectionModel<TDataEntry> where TDataEntry : struct
    {
        public void Apply(MapModel map, TDataEntry data);
    }
}
