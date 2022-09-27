namespace FluentSLAM
{
    public interface ICorrectionModel
    {
        public void Apply(Map map, object data);
    }
}
