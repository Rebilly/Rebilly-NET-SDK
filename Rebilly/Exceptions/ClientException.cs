using System;

namespace Rebilly.Exceptions
{
    public class ClientException : RebillyException
    {
        public ClientException(string message) : base(message) { }
    }
}
