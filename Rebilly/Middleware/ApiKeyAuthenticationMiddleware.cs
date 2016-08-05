using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class ApiKeyAuthenticationMiddleware :  MiddlewareBase
    {
        public string ApiKey { get;  internal set; }
 
        public ApiKeyAuthenticationMiddleware(IRebillyClientContext clientContext)
            : base(clientContext)
        {

        }

        public override void OnRequest(HttpRequestMessage request)
        {
            base.OnRequest(request);

            if(string.IsNullOrEmpty(ApiKey))
            {
                throw new RebillyException("ApiKey cannot be empty");
            }

            request.Headers.Add("REB-APIKEY", ApiKey);
        }
    }
}
