using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class PaymentTokenInstrument : Entity
    {
        public string Pan { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvv { get; set; }
        public int RoutingNumber { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string BankName { get; set; }
    }
}
