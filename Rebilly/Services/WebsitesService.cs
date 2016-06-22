using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class WebsitesService : Service<Website>
    {
        public WebsitesService() : base() { }
        public WebsitesService(string dataProviderName) : base(dataProviderName) { }
    }
}
