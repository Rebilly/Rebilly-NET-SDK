using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class GatewayAccountsService : Service<GatewayAccount>
    {
        public GatewayAccountsService() : base() { }
        public GatewayAccountsService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "gateway-accounts";
        }
    }
}
