namespace FluentSLAM
{
    public interface ICorrectionModel<TDataEntry> where TDataEntry : struct
    {
        public void Apply(IMapModel map, TDataEntry data);
    }


    public interface ICorrectionModel<TDataEntry, TPosition> where TDataEntry : struct
    {
        public void Apply(IMapModel map, TDataEntry data, IMobileObjectModel<TPosition> mobileObject);
    }
}
