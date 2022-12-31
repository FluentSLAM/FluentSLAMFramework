namespace FluentSLAM.MapModels.GraphModel
{
    public struct Vertex
    {
        public readonly double X, Y, Z;

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}