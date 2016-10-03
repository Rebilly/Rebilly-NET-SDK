using System;
using System.IO;
using Newtonsoft.Json;
    
using System.Diagnostics;
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
                var Result = response.Content.ReadAsStringAsync().Result;

                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Debug response for url: " + request.RequestUri);
                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Headers");
                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("HTTP/{0} {1} {2}", response.Version.ToString(), (int)response.StatusCode, response.ReasonPhrase);

                bool ShouldPrettifyJson = false;

                foreach(var header in response.Content.Headers)
                {
                    Debug.WriteLine("{0} = {1}", header.Key, string.Join(",", header.Value));

                    foreach(var val in header.Value)
                    {
                        if(val != null && val.ToLower().Contains("application/json"))
                        {
                            ShouldPrettifyJson = true;
                        }
                    }

                }

                Debug.WriteLine("--------------------------------------------------------------------------------");
                Debug.WriteLine("Content");
                Debug.WriteLine("--------------------------------------------------------------------------------");

                if (ShouldPrettifyJson)
                {
                    try
                    {
                        using (var StringReader = new StringReader(Result))
                        using (var StringWriter = new StringWriter())
                        {
                            var JsonReader = new JsonTextReader(StringReader);
                            var JsonWriter = new JsonTextWriter(StringWriter) { Formatting = Formatting.Indented };
                            JsonWriter.WriteToken(JsonReader);

                            Debug.WriteLine(StringWriter.ToString());
                        }
                    }
                    catch(Exception)
                    {
                        Debug.WriteLine(Result);
                    }
                }
                else
                {
                    Debug.WriteLine(Result);
                }

                
                Debug.WriteLine("");
            }
        }
    }
}
