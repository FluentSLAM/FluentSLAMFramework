namespace FluentSLAM
{
    public interface IMobileObjectModel<TPosition>
    {
        public TPosition? Position { get; set; }
    }
}
