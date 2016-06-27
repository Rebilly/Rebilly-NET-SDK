using System;
using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class ResponseLoggerMiddlware : MiddlewareBase
    {
        public string RequestUriFilter { get; set; }

        public ResponseLoggerMiddlware(IRebillyClientContext clientContext)
            : base(clientContext)
        {

        }

        public override void OnResponse(HttpRequestMessage request,  HttpResponseMessage response)
        {
            base.OnResponse(request, response);

            if (string.IsNullOrEmpty(RequestUriFilter) || request.RequestUri.ToString().Contains(RequestUriFilter.ToLower()))
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
