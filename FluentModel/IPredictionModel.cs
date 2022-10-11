namespace FluentSLAM
{
    public interface IPredictionModel<TDataEntry> where TDataEntry : struct
    {
        public void Apply(MobileObjectModel mobileObject, TDataEntry data);
    }
}
