using Rebilly.Core;

namespace Rebilly.Entities
{
    public class BankAccount : Entity
    {
        public string CustomerId { get ; set;}
        public string ContactId { get ; set;}
        public string BankName { get ; set;}
        public string AccountType { get ; set;}
        public string RoutingNumber { get ; set;}
        public string AccountNumber { get ; set;}
        public string Token { get; set; }
        public string Status { get; set; }

    }
}
