using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class PlansService : Service<Plan>
    {
        public PlansService() : base() { }
        public PlansService(string dataProviderName) : base(dataProviderName) { }
    }
}
