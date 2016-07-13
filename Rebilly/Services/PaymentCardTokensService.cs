using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class PaymentCardTokensService : Service<PaymentCardToken>
    {
        public PaymentCardTokensService() : base() { }
        public PaymentCardTokensService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "tokens";
        }
    }
}
