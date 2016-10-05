using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class PaymentCardsService : Service<PaymentCard>
    {
        public PaymentCardsService() : base() { }
        public PaymentCardsService(string dataProviderName) : base(dataProviderName) { }

        public PaymentCard Authorize(PaymentCardAuthorizationInfo paymentCardAuthorization)
        {
            return Post<PaymentCardAuthorizationInfo>("/" + paymentCardAuthorization.CardId + "/authorization/", paymentCardAuthorization);
        }

        public PaymentCard Deactivate(string cardId)
        {
            return Post<PaymentCardAuthorizationInfo>("/" + cardId + "/deactivation/", null);
        }

        protected override string GetMappedEntityName()
        {
            return "payment-cards";
        }
    }
}
