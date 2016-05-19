using System;
using System.Dynamic;
using Rebilly.Services;

namespace Rebilly
{
    public class Client : DynamicObject
    {
        public static string SandboxHost = "https://api.rebilly.com/v2.1/";
        public static string ProductionHost = "https://api.rebilly.com/v2.1/";

        public string ApiKey { get; private set; }
        public string BaseUrl { get; private set; }

 
        public Client(string apiKey = null, string baseUrl = null)
        {
            if(apiKey == null)
            {
                // TODO: attempt to load from directory
            }
            else
            {
                ApiKey = apiKey;
            }
        }


        public TService GetService<TService>()
        {
            return default(TService);
        }

        /*
        public Service GetService(string serviceName)
        {
            return default(TService);
        }*/

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("Testing: {0}", binder.Name);

            result = "dummy";
            return true;
        }

    }
}
