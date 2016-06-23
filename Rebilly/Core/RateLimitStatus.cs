using System;

namespace Rebilly.Core
{
    public class RateLimitStatus
    {
        public int Limit { get; set; }
        public int Remaining { get; set; }
        public DateTime ResetTime { get; set; }

        public RateLimitStatus()
        {
            Limit = int.MinValue;
            Remaining = int.MinValue;
            ResetTime = DateTime.MinValue;
        }
    }
}
