namespace FluentSLAM.Misc.ObjectPool
{
    public class DefaultObjectCreator<T> : IPoolObjectCreator<T> where T : class, new()
    {
        T IPoolObjectCreator<T>.Create()
        {
            return new T();
        }
    }
}

