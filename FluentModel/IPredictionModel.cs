namespace FluentSLAM
{
    public interface IPredictionModel
    {
        public void Apply(MobileObjectModel mobileObject, DataEntity data);
    }
}
