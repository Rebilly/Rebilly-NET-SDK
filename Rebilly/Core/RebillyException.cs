using System;

namespace Rebilly.Core
{
    public class RebillyException : ApplicationException
    {
        public RebillyException() { }
        public RebillyException(string message) : base(message) 
        { 
        }
    }
}
