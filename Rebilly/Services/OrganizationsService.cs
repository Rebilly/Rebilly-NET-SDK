using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class OrganizationsService : Service<Organization>
    {
        public OrganizationsService() : base() { }
        public OrganizationsService(string dataProviderName) : base(dataProviderName) { }
    }
}
