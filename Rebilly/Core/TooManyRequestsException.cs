
namespace Rebilly.Core
{
    public class TooManyRequestsException : ClientException
    {
        public TooManyRequestsException(ErrorResponseMessage message) : base(message)
        {
        }
    }
}
