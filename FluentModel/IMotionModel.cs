namespace FluentSLAM
{
    public interface IMotionModel<TPosition, TDataEntry> where TDataEntry : struct
    {
        public void Apply(IMobileObjectModel<TPosition> mobileObject, TDataEntry data);
    }
}
