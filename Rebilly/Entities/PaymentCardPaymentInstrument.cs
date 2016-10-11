
namespace Rebilly.Entities
{
    public class PaymentCardPaymentInstrument : PaymentInstrument
    {
        public string PaymentCardId { get; set;  }
        public string GatewayAccountId { get; set; }

        public PaymentCardPaymentInstrument()
        {
            Method = "payment-card";
        }
    }
}
