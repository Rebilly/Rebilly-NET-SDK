
namespace Rebilly.Entities
{
    public class AchPaymentInstrument : PaymentInstrument
    {
        public string BankAccountId { get; set;  }
        public string GatewayAccountId { get; set; }

        public AchPaymentInstrument()
        {
            Method = "ach";
        }
    }
}
