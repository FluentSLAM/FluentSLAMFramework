namespace FluentSLAM
{
    public interface IMotionModel<TMobileObject, TPosition, TDataEntry>
        where TMobileObject : IMobileObjectModel<TPosition>
        where TDataEntry : struct
    {
        public void Apply(TMobileObject mobileObject, TDataEntry data);
    }
}
