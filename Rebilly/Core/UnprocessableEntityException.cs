using Rebilly.Core;

namespace Rebilly.Core
{
    public class UnprocessableEntityException :  ClientException
    {
        public UnprocessableEntityException(RebillyErrorResponseMessage message) : base(message)
        {

        }
    }
}
