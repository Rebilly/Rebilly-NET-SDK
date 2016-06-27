
namespace Rebilly.Core
{
    public interface IRebillyClientContext
    {
        RateLimitStatus RateLimit { get; }
    }
}
