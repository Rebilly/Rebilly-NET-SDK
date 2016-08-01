using System.Collections.Generic;

using Rebilly.Entities;

namespace Rebilly.Core
{
    public class Service<TEntity> : ProviderBase, IService where TEntity : class, IEntity, new()
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
            AssertIdIsSet(id);

            BeforeAction();
            return DataProvider.Load(GetMappedEntityName(), id);
        }


        public Paginator<TEntity> Pagination(SearchArguments arguments = null)
        {
            return new Paginator<TEntity>(this, arguments);
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
            AssertIdIsSet(id);

            var Entity = new TEntity();
            Entity.Id = id;
 
            Delete(Entity);
        }


        public TEntity Post<PostEntity>(string path, PostEntity entity)
        {
            BeforeAction();

            string Path = GetMappedEntityName() + path;

            return DataProvider.Post<PostEntity>(Path, entity);
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


        protected void AssertIdIsSet(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new RebillyException("id cannot be null");
            }
        }
    }
}
