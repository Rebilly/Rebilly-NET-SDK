using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Subscription : Entity
    {
        public string CustomerId { get; set; }
        public string PlanId { get; set; }
        public string WebsiteId { get; set; }
        public string InitialInvoiceId { get; set; }
        public string DeliveryContactId { get; set; }
        public int Quantity { get; set; }
        public bool Autopay { get; set; }
        public string Status { get; set; }

        public string Plan { get; set; }
        public string Website { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? RenewalTime { get; set; }
        public DateTime? CancelledTime { get; set; }
    }
}
