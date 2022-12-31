namespace FluentSLAM
{
    public interface IObservationModel<TMap, TDataEntry>
        where TMap : IMapModel
        where TDataEntry : struct
    {
        public void Apply(TMap map, TDataEntry data);
    }
}