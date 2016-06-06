using System;
using System.Net.Http;

namespace Rebilly.Middleware
{
    public class ResponseLogger : MiddlewareBase
    {
        public override void OnResponse(HttpResponseMessage response)
        {
            base.OnResponse(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
