using System;
using System.Collections.Generic;
using System.Linq;

using System.Net.Http;
using System.Net.Http.Headers;

using Rebilly.Core;

using Newtonsoft.Json;

using Rebilly.Entities;

namespace Rebilly.Core
{
    public class RESTDataProvider<TEntity> : DataProvider<TEntity> where TEntity : IEntity
    {
        public override IList<TEntity> Get(string path, Dictionary<string, string> arguments = null)
        {
            var RelativeUrl = CreateUrl(path, arguments);
            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Get, "");

            return JsonConvert.DeserializeObject<List<TEntity>>(ResponseText);        
        }


        public override TEntity Create(string path, TEntity entity)
        {
            var RelativeUrl = CreateUrl(path, null);

            var SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new JsonSerializeCreatePropertiesResolver()
            };

            var SerializeText = JsonConvert.SerializeObject(entity, SerializerSettings);

            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Post,SerializeText);

            return JsonConvert.DeserializeObject<TEntity>(ResponseText);
        }


        public override TEntity Load(string path, string id)
        {
            var RelativeUrl = CreateUrl(path + "/" + id + "/", null);
            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Get, "");

            return JsonConvert.DeserializeObject<TEntity>(ResponseText);
        }


        public override TEntity Update(string path, TEntity entity)
        {
            var RelativeUrl = CreateUrl(path, null);

            var SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new JsonSerializeUpdatePropertiesResolver()
            };

            var SerializeText = JsonConvert.SerializeObject(entity, SerializerSettings);

            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Put, SerializeText);

            return JsonConvert.DeserializeObject<TEntity>(ResponseText);
        }


        public override void Delete(string path, TEntity entity)
        {
            var RelativeUrl = CreateUrl(path + "/" + entity.Id + "/", null);
            
            // This will throw an exception
            GetJsonText(RelativeUrl, HttpMethod.Delete, "");
        }

    
        public string CreateUrl(string url, Dictionary<string, string> arguments = null)
        {
            if(arguments == null)
            {
                return url;
            }

            return url + string.Join("&", arguments.Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)));
        }


        protected string GetJsonText(string relativeUrl, HttpMethod method, string content)
        {
            using (var Client = CreateClient())
            {
                // TODO: how todo syncronous request: http://stackoverflow.com/questions/14435520/why-use-httpclient-for-synchronous-connection

                var Request = new HttpRequestMessage();
                Request.RequestUri = new Uri((string)this["BaseUrl"] + relativeUrl);

                ApplyMiddlewareToRequest(Request);
                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Request.Method = method;

                if (!string.IsNullOrEmpty(content))
                {
                    Request.Content = new StringContent(content);
                }

                var Response = Client.SendAsync(Request).Result;

                ApplyMiddlewareToResponse(Request, Response);

                ValidateResponse(Response);

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


        private void ApplyMiddlewareToResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            foreach (var middleware in Middleware)
            {
                middleware.OnResponse(request, response);
            }
        }


        protected void ValidateResponse(HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode)
            {
                var Content = response.Content.ReadAsStringAsync().Result;
                var ResponseMessage = JsonConvert.DeserializeObject<RebillyErrorResponseMessage>(Content);
                switch(ResponseMessage.Status)
                {
                    case 422 :
                    {
                        throw new UnprocessableEntityException(ResponseMessage);
                    }
                    default :
                    {
                        throw new ClientException(ResponseMessage);
                    }
                }
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
