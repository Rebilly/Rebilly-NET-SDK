using System;

namespace Rebilly.Entities
{
    public class Entity : IEntity
    {
        public string Id { get; set; }
        public DateTime UpdatedTime { get; set;  }
        public DateTime CreatedTime { get; set; }
    }
}
    