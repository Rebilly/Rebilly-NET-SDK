using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class InvoicesService : Service<Invoice>
    {
        public InvoicesService() : base() { }
        public InvoicesService(string dataProviderName) : base(dataProviderName) { }

        public Invoice Abandon(string invoiceId)
        {
            return Post<Invoice>("/" + invoiceId + "/abandon/",new Invoice());
        }

        public Invoice Void(string invoiceId)
        {
            return Post<Invoice>("/" + invoiceId + "/void/", new Invoice());
        }

        public Invoice Issue(Invoice invoice)
        {
            return Post<Invoice>("/" + invoice.Id + "/issue/", invoice);
        }
    }
}
