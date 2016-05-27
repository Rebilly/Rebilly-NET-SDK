using System.Collections.Generic;

namespace Rebilly.Services
{
    public abstract class DataProvider<TEntity> : PropertyBag, IDataProvider<TEntity>
    {
        public abstract IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
    }
}