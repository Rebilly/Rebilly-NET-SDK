using System.Collections.Generic;

namespace Rebilly.Entities
{
    public class GatewayAccount : Entity
    {
        public string GatewayName { get; set ;}
        public GatewayConfig GatewayConfig { get; set ;}
        public int MerchantCategoryCode { get; set ;}
        public string AcquirerName { get; set; }
        public string Method { get; set; }
        public string OrganizationId { get; set; }
        public string Descriptor { get; set; }
        public string City { get; set; }
        public bool? DynamicDescriptor { get; set; }
        public bool? ThreeDSecure { get; set;  }
        public string ThreeDSecureType { get; set; }
        public double? MonthlyLimit { get; set; }

        public string DowntimeStart { get; set; }
        public string DowntimeEnd { get; set; }

        public List<string> Websites { get; set; }
        public List<string> AcceptedCurrencies { get; set; }
        public List<string> PaymentCardSchemes { get; set; }
    }
}
