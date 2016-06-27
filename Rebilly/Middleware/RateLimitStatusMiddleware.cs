using System;
using System.Linq;

using System.Collections.Generic;
using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class RateLimitStatusMiddleware : MiddlewareBase
    {
        public RateLimitStatusMiddleware(IRebillyClientContext clientContext)
            : base(clientContext)
        {
        }


        public override void OnResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            base.OnResponse(request, response);

            if(response.Headers.Contains("X-Rate-Limit-Limit"))
            {
                IEnumerable<string> Values;
                if (response.Headers.TryGetValues("X-Rate-Limit-Limit", out Values))
                {
                    string XRateLimit = Values.First();
                    ClientContext.RateLimit.Limit = int.Parse(XRateLimit);
                }

            }

            if (response.Headers.Contains("X-Rate-Limit-Remaining"))
            {
                IEnumerable<string> Values;
                if (response.Headers.TryGetValues("X-Rate-Limit-Remaining", out Values))
                {
                    string XRateLimitRemaining = Values.First();
                    ClientContext.RateLimit.Remaining = int.Parse(XRateLimitRemaining);
                }
            }


            if (response.Headers.Contains("X-Rate-Limit-Reset"))
            {
                IEnumerable<string> Values;
                if (response.Headers.TryGetValues("X-Rate-Limit-Reset", out Values))
                {
                    string XRateLimitReset = Values.First();
                    ClientContext.RateLimit.ResetTime = DateTime.Parse(XRateLimitReset);
                }
            }

        }    
    }

}
