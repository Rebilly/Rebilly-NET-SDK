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

            // Use: Middleware logger
            Console.Write(Text);

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
                return Client.GetStringAsync(relativeUrl).Result;
            }
        }


        private HttpClient CreateClient()
        {
            AssertBaseUrlIsNotEmpty();
            AssertApiKeyIsNotEmpty();

            var NewClient = new HttpClient();
            NewClient.BaseAddress = new Uri((string)this["BaseUrl"]);

            NewClient.DefaultRequestHeaders.Clear();
            NewClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            NewClient.DefaultRequestHeaders.Add("REB-APIKEY", (string)this["ApiKey"]);

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
