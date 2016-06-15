using System.Collections.Generic;
using Rebilly.Entities;

namespace Rebilly.Services
{
    public interface IDataProvider<TEntity> : IProviderBase where TEntity : IEntity
    {
        IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
        TEntity Create(string path, TEntity entity);
        TEntity Update(string path, TEntity entity);
        void Delete(string path, TEntity entity);
    }
}
