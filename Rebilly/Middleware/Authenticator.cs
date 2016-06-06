﻿using System.Net.Http;

namespace Rebilly.Middleware
{
    public class Authenticator :  MiddlewareBase
    {
        public string ApiKey { get;  internal set; }

        public override void OnRequest(HttpRequestMessage request)
        {
            base.OnRequest(request);

            request.Headers.Add("REB-APIKEY", ApiKey);
        }
    }
}
