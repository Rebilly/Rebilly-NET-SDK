using System;
using System.Net;
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

            var SerializerSettings = GetSerializerSettings();
            SerializerSettings.ContractResolver = new JsonSerializeCreatePropertiesResolver();

            // Create with a specific Id
            string OldId = string.Empty;
            var CurrentHttpMethod = HttpMethod.Post;
            if(!string.IsNullOrEmpty(entity.Id))
            {
                OldId = entity.Id;
                RelativeUrl += "/" + entity.Id + "/";
                entity.Id = null;
                CurrentHttpMethod = HttpMethod.Put;
            }

            var SerializeText = JsonConvert.SerializeObject(entity, SerializerSettings);

            var ResponseText = GetJsonText(RelativeUrl, CurrentHttpMethod, SerializeText);

            if (!string.IsNullOrEmpty(OldId))
            {
                entity.Id = OldId;
            }

            return DeserializeObject(ResponseText);
        }


        public override TEntity Load(string path, string id)
        {
            var RelativeUrl = CreateUrl(path + "/" + id + "/", null);
            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Get, "");

            return DeserializeObject(ResponseText);            
        }


        public override TEntity Update(string path, TEntity entity)
        {
            var RelativeUrl = CreateUrl(path + "/" + entity.Id + "/", null);

            var SerializerSettings = GetSerializerSettings();
            SerializerSettings.ContractResolver = new JsonSerializeUpdatePropertiesResolver();

            var SerializeText = JsonConvert.SerializeObject(entity, SerializerSettings);

            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Put, SerializeText);

            return DeserializeObject(ResponseText);
        }


        public override void Delete(string path, TEntity entity)
        {
            var RelativeUrl = CreateUrl(path + "/" + entity.Id + "/", null);

            GetJsonText(RelativeUrl, HttpMethod.Delete, "");
        }


        public override TEntity Post<PostEntity>(string path, PostEntity entity)
        {
            var RelativeUrl = CreateUrl(path, null);

            var SerializerSettings = GetSerializerSettings();
            SerializerSettings.ContractResolver = new JsonSerializeUpdatePropertiesResolver();

            string SerializeText = "{}";
            if(entity != null)
            {
                SerializeText = JsonConvert.SerializeObject(entity, SerializerSettings);
            }
                
            var ResponseText = GetJsonText(RelativeUrl, HttpMethod.Post, SerializeText);

            return DeserializeObject(ResponseText);
        }

    
        public string CreateUrl(string url, Dictionary<string, string> arguments = null)
        {
            if(arguments == null)
            {
                return url;
            }

            return url + "?" + string.Join("&", arguments.Select(kv => string.Format("{0}={1}", kv.Key.ToLower(), kv.Value)));
        }


        protected string GetJsonText(string relativeUrl, HttpMethod method, string content)
        {
            using (var Client = CreateClient())
            {
                var Request = new HttpRequestMessage();
                Request.RequestUri = new Uri((string)this["BaseUrl"] + relativeUrl);
                Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Request.Method = method;
 
                if (!string.IsNullOrEmpty(content))
                {
                    Request.Content = new StringContent(content);
                }

                ApplyMiddlewareToRequest(Request);

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


        private JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateFormatString = "yyyy-MM-dd hh:mm:ss",
                NullValueHandling = NullValueHandling.Ignore

            };
        }


        protected void ValidateResponse(HttpResponseMessage response)
        {
            /// TODO: figure out why I need to ignor the moved temporarily response
            if (!response.IsSuccessStatusCode && response.ReasonPhrase.ToLower() != "moved temporarily")
            {
                var Content = response.Content.ReadAsStringAsync().Result;
                var ResponseMessage = JsonConvert.DeserializeObject<ErrorResponseMessage>(Content);
                switch(ResponseMessage.Status)
                {
                    case 422 :
                    {
                        throw new UnprocessableEntityException(ResponseMessage);
                    }
                    case 404:
                    {
                        throw new NotFoundException(ResponseMessage);
                    }
                    case 429:
                    {
                        throw new TooManyRequestsException(ResponseMessage);
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

            var ClientHandler = new HttpClientHandler() { AllowAutoRedirect = false };

            var NewClient = new HttpClient(ClientHandler);
            return NewClient;
        }


        private TEntity DeserializeObject(string responseText)
        {
            var JsonConverters = new JsonConverter[] { new GatewayAccountJsonCreationConverter() };
            return JsonConvert.DeserializeObject<TEntity>(responseText, JsonConverters);
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
