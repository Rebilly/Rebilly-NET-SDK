using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class AuthenticationOptionsService : Service<AuthenticationOption>
    {
        public AuthenticationOptionsService() : base() { }
        public AuthenticationOptionsService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "authentication-options";
        }
    }
}
