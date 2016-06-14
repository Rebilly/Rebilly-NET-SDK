
namespace Rebilly.Entities
{
    public class Organization : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
    }
}
