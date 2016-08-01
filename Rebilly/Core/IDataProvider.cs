using System.Collections.Generic;
using Rebilly.Entities;

namespace Rebilly.Core
{
    public interface IDataProvider<TEntity> : IProviderBase where TEntity : IEntity
    {
        IList<TEntity> Get(string path, Dictionary<string, string> arguments = null);
        TEntity Load(string path, string id);
        TEntity Create(string path, TEntity entity);
        TEntity Update(string path, TEntity entity);
        void Delete(string path, TEntity entity);

        TEntity Post<PostEntity>(string path, PostEntity entity);
    }
}
