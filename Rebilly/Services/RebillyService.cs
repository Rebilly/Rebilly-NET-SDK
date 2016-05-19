using System.Collections.Generic;

using Rebilly.Clients;



namespace Rebilly.Services
{
    public class RebillyService<TEntity> : Service<TEntity>
    {
        private IDataClient<TEntity> _Client = null;
        public RebillyService(IDataClient<TEntity> client)
        {
            _Client = client;
        }


        public IList<TEntity> Search(RebillySearchArguments arguments = null)
        {
            return _Client.Get("");
        }
    }
}
