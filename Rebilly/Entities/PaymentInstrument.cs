using System;
using Rebilly.Core;


namespace Rebilly.Entities
{
    public class PaymentInstrument : Entity
    {
        public string Method { get; protected set; }
    }
}
