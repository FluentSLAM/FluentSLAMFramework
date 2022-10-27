namespace FluentSLAM
{
    public interface IPredictionModel<TPosition, TDataEntry> where TDataEntry : struct
    {
        public void Apply(IMobileObjectModel<TPosition> mobileObject, TDataEntry data);
    }
}
