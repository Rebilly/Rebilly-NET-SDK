using System.Collections.Generic;
using Rebilly.Middleware;


namespace Rebilly.Services
{
    public interface IProviderBase
    {
        object this[string key] { get; set; }
        bool ContainsKey(string key);
        void CopyPropertiesTo(IProviderBase targetBag);
        Stack<MiddlewareBase> Middleware { get; set; }
    }
}
