using Rebilly.Core;

namespace Rebilly.Entities
{
    public class PaymentCard : Entity
    {
        public string CustomerId { get; set;}
        public string Bin { get; set; } 
        public string Pan { get; set;}
        public string ExpYear { get; set;}
        public string ExpMonth { get; set;}
        public string Cvv { get; set;}
        public string BillingContactId { get; set;}
        public string Last4 { get; set; }
        public string Brand { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }

    }
}
