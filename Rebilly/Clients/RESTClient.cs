using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

using Rebilly.Exceptions;

using Newtonsoft.Json;

namespace Rebilly.Clients
{
    public class RESTClient<TEntity>
    {
        public string BaseUrl { get; set; }

        public IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
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
                return Client.GetStringAsync(relativeUrl).Result;
            }
        }

        private HttpClient CreateClient()
        {
            var NewClient = new HttpClient();
            NewClient.BaseAddress = new Uri(BaseUrl);

            NewClient.DefaultRequestHeaders.Clear();
            NewClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return NewClient;
        }


        public void AssertBaseUrlIsNotEmpty()
        {
            if(!string.IsNullOrEmpty(BaseUrl))
            {
                throw new RebillyException("BaseUrl cannot be null or empty");
            }
        }
    }
}
