using System.Collections.Generic;

namespace LaDanse.Migration.KeyMappers
{
    public abstract class GenericKeyMapper<TSourceKey, TTargetKey>
    {
        private readonly Dictionary<TSourceKey, TTargetKey> _keySet;

        protected GenericKeyMapper()
        {
            _keySet = new Dictionary<TSourceKey, TTargetKey>();
        }

        public TTargetKey MapKey(TSourceKey sourceKey)
        {
            if (_keySet.ContainsKey(sourceKey))
                return _keySet[sourceKey];

            var newTargetKey = CreateTargetKey();
            
            _keySet.Add(sourceKey, newTargetKey);

            return newTargetKey;
        }

        protected abstract TTargetKey CreateTargetKey();
    }
}