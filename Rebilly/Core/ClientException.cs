using System;

using Rebilly.Core;

namespace Rebilly.Core
{
    public class ClientException : RebillyException
    {
        public ErrorResponseMessage StatusMessage { get; private set; }

        public int Status 
        {
            get
            {
                return StatusMessage.Status;
            }
        }


        public string Error
        {
            get
            {
                return StatusMessage.Error;
            }
        }


        public ClientException()
        {
            StatusMessage = new ErrorResponseMessage();
        }


        public ClientException(ErrorResponseMessage message) : base(message.FullMessage)
        {
            StatusMessage = message;
        }
    }
}
