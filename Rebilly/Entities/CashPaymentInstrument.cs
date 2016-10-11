namespace Rebilly.Entities
{
    public class CashPaymentInstrument : PaymentInstrument
    {
        public string ReceivedBy { get; set;  }

        public CashPaymentInstrument()
        {
            Method = "cash";
        }
    }
}
