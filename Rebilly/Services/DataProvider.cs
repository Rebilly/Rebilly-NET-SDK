using System.Collections.Generic;

namespace Rebilly.Services
{
    public abstract class DataProvider<TEntity> : ProviderBase, IDataProvider<TEntity>
    {
        public abstract IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
    }
}