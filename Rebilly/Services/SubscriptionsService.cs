using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class SubscriptionsService : Service<Subscription>
    {
        public SubscriptionsService() : base() { }
        public SubscriptionsService(string dataProviderName) : base(dataProviderName) { }
    }
}
