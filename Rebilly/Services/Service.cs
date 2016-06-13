using System.Collections.Generic;


namespace Rebilly.Services
{
    public class Service<TEntity> : ProviderBase, IService
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
