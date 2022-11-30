namespace FluentSLAM
{
    public interface IMotionModel<TMobileObject, TDataEntry>
        where TMobileObject : IMobileObjectModel
        where TDataEntry : struct
    {
        public void Apply(TMobileObject mobileObject, TDataEntry data);
    }
}
