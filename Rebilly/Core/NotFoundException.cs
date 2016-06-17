
namespace Rebilly.Core
{
    public class NotFoundException : ClientException
    {
        public NotFoundException(RebillyErrorResponseMessage message) : base(message)
        {

        }
    }
}
