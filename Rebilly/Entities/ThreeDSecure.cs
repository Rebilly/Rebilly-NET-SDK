using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class ThreeDSecure : Entity
    {
        public string CustomerId { get; set; }
        public string GatewayAccountId { get; set; }
        public string PaymentCardId { get; set; }
        public string WebsiteId { get; set; }
        public string Enrolled { get; set; }
        public string EnrollmentEci { get; set; }
        public int Eci { get; set;  }
        public string Cavv { get; set; }
        public string Xid { get; set; }
        public string PayerAuthResponseStatus { get; set; }
        public string SignatureVerification { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

    }
}
