using Rebilly.Core;

namespace Rebilly.Entities
{
    public class PaymentCardAuthorizationInfo : Entity
    {
        public string CardId { get; set; }
        public string Currency { get; set; }
        public string WebsiteId { get; set; } 
    }
}
