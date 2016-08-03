using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class PaymentCardTokensService : Service<PaymentCardToken>
    {
        public PaymentCardTokensService() : base() { }
        public PaymentCardTokensService(string dataProviderName) : base(dataProviderName) { }


        public PaymentCardToken Expire(string tokenId)
        {
            return Post<PaymentCardToken>("/" + tokenId + "/expiration/", new PaymentCardToken());
        }

        protected override string GetMappedEntityName()
        {
            return "tokens";
        }
    }
}
