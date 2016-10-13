using System.Collections.Generic;

using Rebilly.Entities;

namespace Rebilly.Core
{
    public abstract class DataProvider<TEntity> : ProviderBase, IDataProvider<TEntity> where TEntity : IEntity
    {
        public abstract IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
        public abstract TEntity GetSingle(string path, Dictionary<string, string> arguments = null);
        public abstract TEntity Load(string path, string id);
        public abstract TEntity Create(string path, TEntity entity);
        public abstract TEntity Update(string path, TEntity entity);
        public abstract void Delete(string path, TEntity entity);

        public abstract TEntity Post<PostEntity>(string path, PostEntity entity);
    }
}