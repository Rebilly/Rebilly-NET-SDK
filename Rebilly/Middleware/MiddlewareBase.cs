using System.Net.Http;

namespace Rebilly.Middleware
{
    public class MiddlewareBase
    {
        public virtual void OnRequest(HttpRequestMessage request) { }
        public virtual void OnResponse(HttpResponseMessage response) { }

    }
}
