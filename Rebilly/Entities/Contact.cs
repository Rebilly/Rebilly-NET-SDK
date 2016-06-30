using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Contact : Entity
    {
        public string CustomerId { get; set;  }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
