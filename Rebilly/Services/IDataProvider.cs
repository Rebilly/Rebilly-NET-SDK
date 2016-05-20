using System.Collections.Generic;

namespace Rebilly.Services
{
    public interface IDataProvider<TEntity> : IPropertyBag
    {
        IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
    }
}
