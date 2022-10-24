namespace FluentSLAM
{
    public interface IPredictionModel<TDataEntry> where TDataEntry : struct
    {
        public void Apply(IMobileObjectModel mobileObject, TDataEntry data);
    }
}
