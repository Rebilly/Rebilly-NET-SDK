using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class ThreeDSecuresService : Service<ThreeDSecure>
    {
        public ThreeDSecuresService() : base() { }
        public ThreeDSecuresService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "3dsecure";
        }
    }
}
