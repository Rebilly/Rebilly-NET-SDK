using System.Collections.Generic;

using Rebilly.Core;
using Rebilly.Entities;

namespace Rebilly.Services
{
    public class Service<TEntity> : ProviderBase, IService where TEntity : IEntity
    {
        public IDataProvider<TEntity> DataProvider { get; private set; }

        public Service() { }

        public Service(IDataProvider<TEntity> dataProvider)
        {
            DataProvider = dataProvider;
        }


        public Service(string dataProviderName) 
        {
            SetDataProvider(dataProviderName);
        }


        public void SetDataProvider(string dataProviderName)
        {
            var Factory = new DataProviderFactory<TEntity>();
            DataProvider = Factory.Create(dataProviderName);
        }


        public TEntity Create(TEntity entity)
        {
            BeforeAction();

            return DataProvider.Create(GetMappedEntityName(), entity);
        }


        public IList<TEntity> Search(RebillySearchArguments arguments = null)
        {
            BeforeAction();

            return DataProvider.Get(GetMappedEntityName());
        }


        public void Delete(TEntity entity)
        {
            BeforeAction();

            DataProvider.Delete(GetMappedEntityName(), entity);            
        }


        public void Delete(string id)
        {
            var Entity = default(TEntity);
            Entity.Id = id;
 
            Delete(Entity);
        }


        protected virtual void BeforeAction()
        {
            CopyPropertiesTo(DataProvider);
            DataProvider.Middleware = Middleware;
        }


        protected virtual string GetMappedEntityName()
        {
            var TypeName = typeof(TEntity).Name;
            return TypeName.ToLower() + "s";
        }
    }
}
