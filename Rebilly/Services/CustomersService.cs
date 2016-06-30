using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class CustomersService : Service<Customer>
    {
        public CustomersService() : base() { }
        public CustomersService(string dataProviderName) : base(dataProviderName) { }
    }
}
