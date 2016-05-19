using System.Collections.Generic;

namespace Rebilly.Clients
{
    public interface IDataClient<TEntity>
    {
        IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
    }
}
