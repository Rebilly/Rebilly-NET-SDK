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

        public string Plan { get; set; }
        public string Website { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }


        /*
        "customerId"
  "planId"
  "websiteId"
  "initialInvoiceId"
  "deliveryContactId"
  "quantity"
  "autopay"

         "plan": "54be26d01294a",
  "website": "N4FTS",
  "billingAddress": "8256644118816261",
  "deliveryAddress": "8256644118816261",
  "startTime": "2015-01-01 00:00:00",
  "endTime": null,
  "renewalTime": "2015-02-01 00:00:00",
  "cancelledTime": null,
  "status": "Active",
  "quantity": "1",
        */
    }
}
