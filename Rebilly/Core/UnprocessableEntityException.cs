using Rebilly.Core;

namespace Rebilly.Core
{
    public class UnprocessableEntityException :  ClientException
    {
        public UnprocessableEntityException(ErrorResponseMessage message) : base(message)
        {

        }
    }
}
