using System.Collections.Generic;

using Rebilly.Services;
using Rebilly.Entities;

namespace Rebilly.Core
{
    public class PaginatorEnumerator<TEntity> : IEnumerator<TEntity> where TEntity : class, IEntity, new()
    {
        private int _RelativePosition = -1;
        private IList<TEntity> _Items = null;

        private Service<TEntity> _Service = null;
        private SearchArguments _Arguments = null;

        public PaginatorEnumerator(Service<TEntity> service, SearchArguments arguments)
        {
            _Service = service;
            _Arguments = arguments;
        }


        public TEntity Current
        {
            get
            {
                if (_RelativePosition == -1)
                {
                    return null;
                }

                return _Items[_RelativePosition];
            }
        }

       
        object System.Collections.IEnumerator.Current
        {
            get 
            { 
                return Current;
            }
        }


        public bool MoveNext()
        {
            // Are we at the begnning or the end of the list.
            if (_RelativePosition == -1 || _RelativePosition >= (_Items.Count - 1))
            {
                return LoadNextEntities();
            }
            else
            {
                _RelativePosition++;
                return true;
            }
        }


        public void Reset()
        {
            _RelativePosition = -1;
            if (_Items != null)
            {
                _Items.Clear();
            }
        }


        private bool LoadNextEntities()
        {
            if (_RelativePosition != -1)
            {
                _Arguments.Offset += _Arguments.Limit;
            }

            _Items = _Service.Search(_Arguments);
            if (_Items.Count > 0)
            {
                _RelativePosition = 0;
                return true;
            }
            else
            {
                _RelativePosition = -1;
                return false;
            }

        }

        public void Dispose()
        {
        
        }
    }
}
