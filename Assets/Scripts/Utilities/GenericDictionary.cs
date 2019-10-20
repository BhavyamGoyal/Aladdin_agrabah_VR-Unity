using System.Collections.Generic;

namespace Utils
{
    public class GenericDictionary<Y>
    {
        private Dictionary<Y, object> _dict = new Dictionary<Y,object>();
        public void Add<T>(Y key, T value) where T : class
        {
            _dict.Add(key, value);
        }

        public T GetValue<T>(Y key) where T : class
        {
            T call = _dict[key] as T;
            _dict.Remove(key);
            return call;
        }
    }
}