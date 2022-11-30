namespace FluentSLAM
{
    public interface IMobileObjectModel
    {

    }

    public interface IMobileObjectModel<TPosition> : IMobileObjectModel
    {
        public TPosition? Position { get; set; }
    }
}
