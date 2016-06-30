using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class NotesService : Service<Note>
    {
        public NotesService() : base() { }
        public NotesService(string dataProviderName) : base(dataProviderName) { }
    }
}
