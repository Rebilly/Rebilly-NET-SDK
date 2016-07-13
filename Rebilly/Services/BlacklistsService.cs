using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class BlacklistsService : Service<Blacklist>
    {
        public BlacklistsService() : base() { }
        public BlacklistsService(string dataProviderName) : base(dataProviderName) { }
    }
}
