
namespace Rebilly.Core
{
    public class NotFoundException : ClientException
    {
        public NotFoundException(ErrorResponseMessage message) : base(message)
        {

        }
    }
}
