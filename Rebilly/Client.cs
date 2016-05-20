using System;
using System.Dynamic;
using Rebilly.Services;

namespace Rebilly
{
    public class Client : DynamicObject
    {
        public static string SandboxHost = "https://api.rebilly.com/v2.1/";
        public static string ProductionHost = "https://api.rebilly.com/v2.1/";

        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }

 
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

            if(baseUrl == null)
            {
                BaseUrl = ProductionHost;
            }
            else
            {
                BaseUrl = baseUrl;
            }
        }


        public TService GetService<TService>() where TService : PropertyBag, IService, new()
        {
            var Factory = new ServiceFactory();
            var NewService = Factory.Create<TService>();

            SetPropertyBag(NewService);

            return NewService;
        }


        protected object GetService(string serviceName)
        {
            var Factory = new ServiceFactory();
            var NewService = Factory.Create(serviceName);

            SetPropertyBag(NewService);

            return NewService;
        }


        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = GetService(binder.Name);
            return true;
        }


        private void SetPropertyBag(PropertyBag targetBag)
        {
            targetBag["ApiKey"] = ApiKey;
            targetBag["BaseUrl"] = BaseUrl;
        }
    }
}
