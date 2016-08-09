using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Invoice : Entity
    {
        public string CustomerId { get; set; }
        public string WebsiteId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public string BillingContactId { get; set; }
        public string DeliveryContactId { get; set; }

        public string[] Items { get; set; }

        public DateTime? AbandonedTime { get ; set;}
        public DateTime? VoidedTime { get ; set;}
        public DateTime? ClosedTime { get ; set;}
        public DateTime? DueTime { get ; set;}
        public DateTime? IssuedTime { get ; set;}    
    }
 }


