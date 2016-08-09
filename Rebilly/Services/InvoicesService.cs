using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class InvoicesService : Service<Invoice>
    {
        public InvoicesService() : base() { }
        public InvoicesService(string dataProviderName) : base(dataProviderName) { }
    }
}
