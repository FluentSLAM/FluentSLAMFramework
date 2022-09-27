namespace FluentSLAM
{
    public interface IPredictionModel
    {
        public void Apply(MobileObject mobileObject, object data);
    }
}
