using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Blacklist : Entity
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public int Ttl { get; set; }

        public DateTime? ExpireTime { get; set; }
    }
}
