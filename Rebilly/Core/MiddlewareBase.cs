using System.Net.Http;

namespace Rebilly.Core
{
    public class MiddlewareBase
    {
        public IRebillyClientContext ClientContext { get; private set; }

        public MiddlewareBase(IRebillyClientContext clientContext)
        {
            ClientContext = clientContext;
        }

        public virtual void OnRequest(HttpRequestMessage request) { }
        public virtual void OnResponse(HttpRequestMessage request, HttpResponseMessage response) { }
    }
}
