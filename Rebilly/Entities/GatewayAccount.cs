using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebilly.Entities
{
    public class GatewayAccount : Entity
    {


        public string GatewayName { get; set ;}
        public GatewayConfig GatewayConfig { get; set ;}
        public string MerchantCategoryCode { get; set ;}
        public string AcquirerName { get; set; }
        public string Method { get; set; }
        public string OrganizationId { get; set; }
        public string Descriptor { get; set; }
        public List<string> Websites { get; set; }


        public List<string> AcceptedCurrencies { get; set; }

        /*
 *   "paymentMethods"
 *   "descriptor",
 *   "city",
 *   "dynamicDescriptor"
 *   "can3DSecure"
 *   "monthlyLimit",
 *   "acceptedCurrencies",
 *   "downtimeStart",
 *   "downtimeEnd",
        */


    }
}
