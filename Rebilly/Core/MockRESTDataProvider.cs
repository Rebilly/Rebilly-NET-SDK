using System.Collections.Generic;

using Rebilly.Entities;

namespace Rebilly.Core
{
    public class MockRESTDataProvider<TEntity> : DataProvider<TEntity> where TEntity : IEntity
    {
        public override IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
        {
            return null;
        }

        public override TEntity GetSingle(string path, Dictionary<string, string> arguments = null)
        {
            return default(TEntity);
        }


        public override TEntity Load(string path, string id)
        {
            return default(TEntity);
        }


        public override TEntity Create(string path, TEntity entity)
        {
            return entity;
        }


        public override TEntity Update(string path, TEntity entity)
        {
            return entity;
        }


        public override void Delete(string path, TEntity entity)
        {

        }


        public override TEntity Post<PostEntity>(string path, PostEntity entity)
        {
            return default(TEntity);
        }
    }
}
