using System.Collections.Concurrent;

namespace FluentSLAM.Misc.ObjectPool
{
    public class Pool<T>
        where T : class, IPoolable, new()
    {
        private readonly ConcurrentBag<T> _container = new ConcurrentBag<T>();
        private readonly IPoolObjectCreator<T> _objectCreator;

        public int Count => this._container.Count;


        public Pool()
        {
            _objectCreator = new DefaultObjectCreator<T>();
        }

        public Pool(IPoolObjectCreator<T> creator)
        {
            if (creator == null)
                throw new ArgumentNullException(nameof(creator));
            this._objectCreator = creator;
        }

        public T Get()
        {
            T obj;
            if (this._container.TryTake(out obj))
                return obj;
            return this._objectCreator.Create();
        }

        public void Return(ref T obj)
        {
            obj.Reset();
            this._container.Add(obj);
            obj = null;
        }
    }
}