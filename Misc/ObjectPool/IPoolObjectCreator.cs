namespace FluentSLAM.Misc.ObjectPool
{
    public interface IPoolObjectCreator<T>
    {
        T Create();
    }
}