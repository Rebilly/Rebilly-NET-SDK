using System;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
    
using System.Diagnostics;
using System.Net.Http;

using Rebilly.Core;

namespace Rebilly.Middleware
{
    public class AnalyzerMiddlware : MiddlewareBase
    {
        public string RequestUriFilter { get; set; }

        public AnalyzerMiddlware(IRebillyClientContext clientContext)
            : base(clientContext)
        {

        }


        public override void OnRequest(HttpRequestMessage request)
        {
            base.OnRequest(request);

            if (string.IsNullOrEmpty(RequestUriFilter) || request.RequestUri.ToString().Contains(RequestUriFilter.ToLower()))
            {
                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Debug request for: " + GetRequestSummary(request));
                Debug.WriteLine("--------------------------------------------------------------------------------");
                foreach (var header in request.Headers)
                {
                    Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                }

                bool ShouldPrettifyJson = GetShouldPrettifyJson(request.Headers);
                var Response = GetContentResponse(request.Content, ShouldPrettifyJson);
                Debug.WriteLine(Response);


                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("");
            }
        }

        public override void OnResponse(HttpRequestMessage request,  HttpResponseMessage response)
        {
            base.OnResponse(request, response);

            if (string.IsNullOrEmpty(RequestUriFilter) || request.RequestUri.ToString().Contains(RequestUriFilter.ToLower()))
            {
                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Debug response for: " + GetRequestSummary(request));
                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("HTTP/{0} {1} {2}", response.Version.ToString(), (int)response.StatusCode, response.ReasonPhrase);

                

                foreach(var header in response.Content.Headers)
                {
                    Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                }

                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Content");
                Debug.WriteLine("--------------------------------------------------------------------------------");

                bool ShouldPrettifyJson = GetShouldPrettifyJson(response.Content.Headers);
                var Response = GetContentResponse(response.Content, ShouldPrettifyJson);
                Debug.WriteLine(Response);
                
                Debug.WriteLine("");
            }
        }

        private string GetRequestSummary(HttpRequestMessage request)
        {
            return request.Method.ToString() + " " + request.RequestUri + " HTTP/" + request.Version.ToString();
        }


        private bool GetShouldPrettifyJson(HttpContentHeaders headers)
        {
            foreach (var header in headers)
            {
                foreach (var val in header.Value)
                {
                    if (val != null && val.ToLower().Contains("application/json"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool GetShouldPrettifyJson(HttpRequestHeaders headers)
        {
            foreach (var header in headers)
            {

                foreach (var val in header.Value)
                {
                    if (val != null && val.ToLower().Contains("application/json"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private string GetContentResponse(HttpContent content, bool shouldPrettifyJson)
        {
            if(content == null)
            {
                return "";
            }

            var Result  = content.ReadAsStringAsync().Result;

            if (shouldPrettifyJson)
            {
                try
                {
                    using (var StringReader = new StringReader(Result))
                    using (var StringWriter = new StringWriter())
                    {
                        var JsonReader = new JsonTextReader(StringReader);
                        var JsonWriter = new JsonTextWriter(StringWriter) { Formatting = Formatting.Indented };
                        JsonWriter.WriteToken(JsonReader);

                        return StringWriter.ToString();
                    }
                }
                catch(Exception)
                {
                    return Result;
                }
            }
            else
            {
                return Result;                
            }
        }                  
    }
}
