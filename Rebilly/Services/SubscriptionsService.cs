using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class SubscriptionsService : Service<Subscription>
    {
        public SubscriptionsService() : base() { }
        public SubscriptionsService(string dataProviderName) : base(dataProviderName) { }


        public Subscription Cancel(string subscriptionId, string policy = "at-next-renewal")
        {
            return Post<SubscriptionCancelPolicy>("/" + subscriptionId + "/cancel/", new SubscriptionCancelPolicy() { Policy = policy });
        }
    }
}
