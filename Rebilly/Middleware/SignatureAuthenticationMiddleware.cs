using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class SignatureAuthenticationMiddleware : MiddlewareBase
    {
        public string ApiKey { get;  set; }
        public string ApiUser { get;  set; }

        public SignatureAuthenticationMiddleware(IRebillyClientContext clientContext)
            : base(clientContext)
        {
        }

        public override void OnRequest(HttpRequestMessage request)
        {
            base.OnRequest(request);

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new RebillyException("ApiKey cannot be empty");
            }

            if (string.IsNullOrEmpty(ApiUser))
            {
                throw new RebillyException("ApiUser cannot be empty");
            }

            var NewSignature = new Signature();
            var SignatureText = NewSignature.Generate(ApiUser, ApiKey);


            request.Headers.Add("REB-AUTH", SignatureText);
        }
    }
}
