using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class LeadSourcesService : Service<LeadSource>
    {
        public LeadSourcesService() : base() { }
        public LeadSourcesService(string dataProviderName) : base(dataProviderName) { }
    }
}