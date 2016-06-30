
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Note : Entity
    {
        public string Content { get; set; }
        public string RelatedType { get; set; }
        public string RelatedId { get; set; }
        public bool Archived { get; set;  }
    }
}
