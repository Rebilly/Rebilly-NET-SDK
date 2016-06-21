using System.Collections.Generic;

using Rebilly.Core;
using Rebilly.Entities;

namespace Rebilly.Services
{
    public class Service<TEntity> : ProviderBase, IService where TEntity : IEntity, new()
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


        public TEntity Load(string id)
        {
            BeforeAction();
            return DataProvider.Load(GetMappedEntityName(), id);
        }


        public Pager<TEntity> Pagination(SearchArguments arguments = null)
        {
            return new Pager<TEntity>();
        }


        public IList<TEntity> Search(SearchArguments arguments = null)
        {
            BeforeAction();

            Dictionary<string, string> Arguments = null;
            if(arguments != null)
            {
                var Converter = new SearchArgumentsConverter();
                Arguments = Converter.ToDictionary(arguments);
            }

            return DataProvider.Get(GetMappedEntityName(), Arguments);
        }


        public void Delete(TEntity entity)
        {
            BeforeAction();
            DataProvider.Delete(GetMappedEntityName(), entity);            
        }


        public TEntity Update(TEntity entity)
        {
            BeforeAction();
            return DataProvider.Update(GetMappedEntityName(), entity);
        }


        public void Delete(string id)
        {
            var Entity = new TEntity();
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
