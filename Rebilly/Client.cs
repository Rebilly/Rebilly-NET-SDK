using System;
using System.Dynamic;
using Rebilly.Services;
using Rebilly.Middleware;
using System.Collections.Generic;

namespace Rebilly
{
    public class Client : DynamicObject
    {
        public static string SandboxHost = "https://api.rebilly.com/v2.1/";
        public static string ProductionHost = "https://api.rebilly.com/v2.1/";

        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }

        public Stack<MiddlewareBase> Middleware { get; set; }
 
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

            Initialize();
        }


        public GatewayAccountsService GatewayAccounts()
        {
            return GetService<GatewayAccountsService>();
        }


        public TService GetService<TService>() where TService : ProviderBase, IService, new()
        {
            var Factory = new ServiceFactory();
            var NewService = Factory.Create<TService>();

            SetProviderBase(NewService);

            return NewService;
        }


        protected object GetService(string serviceName)
        {
            var Factory = new ServiceFactory();
            var NewService = Factory.Create(serviceName);

            SetProviderBase(NewService);

            return NewService;
        }


        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = GetService(binder.Name);
            return true;
        }


        private void SetProviderBase(ProviderBase providerBase)
        {
            providerBase["ApiKey"] = ApiKey;
            providerBase["BaseUrl"] = BaseUrl;

            providerBase.Middleware = Middleware;
        }


        private void Initialize()
        {
            Middleware = new Stack<MiddlewareBase>();

            Middleware.Push(new AuthenticatorMiddleware() { ApiKey = ApiKey });
        }

    }
}
