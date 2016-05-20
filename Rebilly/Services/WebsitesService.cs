using Rebilly.Entities;


namespace Rebilly.Services
{
    public class WebsitesService : Service<Website>
    {
        public WebsitesService() : base() { }
        public WebsitesService(string dataProviderName) : base(dataProviderName) { }
    }
}
