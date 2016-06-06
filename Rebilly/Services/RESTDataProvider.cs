using System;
using System.Collections.Generic;
using System.Linq;

using System.Net.Http;
using System.Net.Http.Headers;

using Rebilly.Exceptions;

using Newtonsoft.Json;

namespace Rebilly.Services
{
    public class RESTDataProvider<TEntity> : DataProvider<TEntity>
    {
        public override IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
        {
            var RelativeUrl = CreateUrl(path, arguments);
            var Text = GetJsonText(RelativeUrl);

            return JsonConvert.DeserializeObject<List<TEntity>>(Text);        
        }

    
        public string CreateUrl(string url, Dictionary<string, string> arguments = null)
        {
            if(arguments == null)
            {
                return url;
            }

            return url + string.Join("&", arguments.Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)));
        }


        protected string GetJsonText(string relativeUrl)
        {
            using (var Client = CreateClient())
            {
                // TODO: how todo syncronous request: http://stackoverflow.com/questions/14435520/why-use-httpclient-for-synchronous-connection

                var Request = new HttpRequestMessage();
                Request.RequestUri = new Uri((string)this["BaseUrl"] + relativeUrl);

                ApplyMiddlewareToRequest(Request);
                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var Response = Client.SendAsync(Request).Result;

                ApplyMiddlewareToResponse(Response);

                return Response.Content.ReadAsStringAsync().Result;
            }
        }


        private void ApplyMiddlewareToRequest(HttpRequestMessage request)
        {
            foreach(var middleware in Middleware)
            {
                middleware.OnRequest(request);
            }
        }


        private void ApplyMiddlewareToResponse(HttpResponseMessage response)
        {
            foreach (var middleware in Middleware)
            {
                middleware.OnResponse(response);
            }
        }


        private HttpClient CreateClient()
        {
            AssertBaseUrlIsNotEmpty();
            AssertApiKeyIsNotEmpty();

            var NewClient = new HttpClient();
            return NewClient;
        }


        private void AssertBaseUrlIsNotEmpty()
        {
            if(!ContainsKey("BaseUrl"))
            {
                throw new RebillyException("BaseUrl cannot be null or empty");
            }
        }

        private void AssertApiKeyIsNotEmpty()
        {
            if(!ContainsKey("ApiKey"))
            {
                throw new RebillyException("ApiKey cannot be null or empty");
            }
        }
    }
}
