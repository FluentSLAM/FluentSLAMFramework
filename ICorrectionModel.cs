namespace FluentSLAM
{
    public interface ICorrectionModel
    {
        public void Apply(MapModel map, object data);
    }
}
