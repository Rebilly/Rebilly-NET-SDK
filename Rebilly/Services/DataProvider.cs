using System.Collections.Generic;

using Rebilly.Entities;

namespace Rebilly.Services
{
    public abstract class DataProvider<TEntity> : ProviderBase, IDataProvider<TEntity> where TEntity : IEntity
    {
        public abstract IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
        public abstract TEntity Create(string path, TEntity entity);
        public abstract TEntity Update(string path, TEntity entity);
        public abstract void Delete(string path, TEntity entity);
    }
}