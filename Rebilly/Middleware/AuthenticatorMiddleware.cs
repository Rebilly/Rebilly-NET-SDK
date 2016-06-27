using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class AuthenticatorMiddleware :  MiddlewareBase
    {
        public string ApiKey { get;  internal set; }

        public AuthenticatorMiddleware(IRebillyClientContext clientContext)
            : base(clientContext)
        {

        }

        public override void OnRequest(HttpRequestMessage request)
        {
            base.OnRequest(request);

            request.Headers.Add("REB-APIKEY", ApiKey);
        }
    }
}
