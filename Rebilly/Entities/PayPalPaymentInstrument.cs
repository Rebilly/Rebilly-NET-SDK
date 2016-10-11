
namespace Rebilly.Entities
{
    public class PayPalPaymentInstrument : PaymentInstrument
    {
        public string PayPalAccountId { get; set; }
        public string GatewayAccountId { get; set; }

        public PayPalPaymentInstrument()
        {
            Method = "pay-pal";
        }
    }
}
