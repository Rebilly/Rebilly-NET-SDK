using System;
using System.Collections.Generic;

using Rebilly.Core;

namespace Rebilly.Services
{
    public class ServiceFactory
    {
        public TService Create<TService>(string dataProviderName = "REST") where TService : ProviderBase, IService, new()
        {
            var NewService = new TService();
            NewService.SetDataProvider(dataProviderName);

            return NewService;
        }

        public ProviderBase Create(string serviceName, string dataProviderName = "REST")
        {
            if(string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException(serviceName);
            }

            // Could use a reflection to create an instance also
            switch(serviceName)
            {
                case "Websites": 
                {
                    return new WebsitesService(dataProviderName);
                }
                case "GatewayAccounts":
                {
                    return new GatewayAccountsService(dataProviderName);
                }
                default:
                {
                    throw new RebillyException(string.Format("Cannot find service {0}", serviceName));
                }
            }            
        }

    }
}
