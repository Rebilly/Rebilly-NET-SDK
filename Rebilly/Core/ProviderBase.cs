﻿using System.Collections.Generic;
using Rebilly.Middleware;

namespace Rebilly.Core
{
    public class ProviderBase
    {
        private Dictionary<string, object> _Properties = new Dictionary<string, object>();
        public List<MiddlewareBase> Middleware { get; set; }

        public ProviderBase()
        {
            Middleware = new List<MiddlewareBase>(); 
        }

        public object this[string key]
        {
            get
            {
                return _Properties[key];
            }
            set
            {
                if (!ContainsKey(key))
                {
                    _Properties.Add(key, value);
                }
                else
                {
                    _Properties[key] = value;
                }
            }
        }


        public bool ContainsKey(string key)
        {
            return _Properties.ContainsKey(key);
        }


        public void CopyPropertiesTo(IProviderBase targetBag)
        {
            foreach(var pair in _Properties)
            {
                targetBag[pair.Key] = pair.Value;
            }
        }
    }
}
