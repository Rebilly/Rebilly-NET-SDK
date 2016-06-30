using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class ContactsService : Service<Contact>
    {
        public ContactsService() : base() { }
        public ContactsService(string dataProviderName) : base(dataProviderName) { }
    }
}
