using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Customer : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set;  }
        public string DefaultCard { get; set; }
    }
}
