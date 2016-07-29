using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class PaymentCardsService : Service<PaymentCard>
    {
        public PaymentCardsService() : base() { }
        public PaymentCardsService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "payment-cards";
        }
    }
}
