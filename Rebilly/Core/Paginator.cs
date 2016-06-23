using System.Collections.Generic;
using System.Collections;

using Rebilly.Services;
using Rebilly.Entities;

namespace Rebilly.Core
{
    public class Paginator<TEntity> : IEnumerable<TEntity> where TEntity : class, IEntity, new()
    {
        private Service<TEntity> _Service = null;
        private SearchArguments _Arguments = null;

        public Paginator(Service<TEntity> service, SearchArguments arguments)
        {
            _Service = service;
            _Arguments = arguments;
        }

    
        public IEnumerator<TEntity> GetEnumerator()
        {
            return new PaginatorEnumerator<TEntity>(_Service, _Arguments);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
 	        return (IEnumerator)GetEnumerator();
        }
    }
}
