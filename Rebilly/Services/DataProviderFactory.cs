using System;

using Rebilly.Core;
using Rebilly.Entities;

namespace Rebilly.Services
{
    public class DataProviderFactory<TEntity> where TEntity : IEntity
    {
        public IDataProvider<TEntity> Create(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
            {
                throw new ArgumentNullException(providerName);
            }

            if (providerName == "REST")
            {
                return new RESTDataProvider<TEntity>();
            }
            else if (providerName == "MockREST")
            {
                return new MockRESTDataProvider<TEntity>();
            }

            throw new RebillyException(string.Format("Cannot find service {0}", providerName));
        }
    }
}
