using System;
using Rebilly.Exceptions;

namespace Rebilly.Services
{
    public class ServiceFactory
    {
        public TService Create<TService>(string dataProviderName = "REST") where TService : PropertyBag, IService, new()
        {
            var NewService = new TService();
            NewService.SetDataProvider(dataProviderName);

            return NewService;
        }

        public PropertyBag Create(string serviceName, string dataProviderName = "REST")
        {
            if(string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException(serviceName);
            }

            if(serviceName == "Websites")
            {
                return new WebsitesService(dataProviderName);
            }
            else if(serviceName == "GatewayAccounts")
            {
                return new GatewayAccountsService(dataProviderName);
            }

            throw new RebillyException(string.Format("Cannot find service {0}", serviceName));
        }
    }
}
