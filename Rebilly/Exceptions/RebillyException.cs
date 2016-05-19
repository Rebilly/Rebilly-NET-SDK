using System;

namespace Rebilly.Exceptions
{
    public class RebillyException : ApplicationException
    {
        public RebillyException(string message) : base(message) { }
    }
}
