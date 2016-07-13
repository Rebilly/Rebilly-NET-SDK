using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class PaymentCardToken : Entity
    {
        public string Method { get; set;}
        public string PaymentInstrument { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Address { get; set;}
        public string Address2 { get; set;}
        public string City { get; set;}
        public string Region { get; set;}
        public string Country { get; set;}
        public string PhoneNumber { get; set;}
        public string PostalCode { get; set;}
        public string Fingerprint { get; set;}
        public DateTime? ExpiredTime { get; set; }
        public DateTime? UsedTime { get; set; }
    }
}
