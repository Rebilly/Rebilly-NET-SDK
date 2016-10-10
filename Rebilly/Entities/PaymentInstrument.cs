using System;
using Rebilly.Core;


namespace Rebilly.Entities
{
    public abstract class PaymentInstrument : Entity
    {
        public string Method { get; protected set; }
    }
}
