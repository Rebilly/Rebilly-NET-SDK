using System;
using System.Collections.Generic;

namespace Rebilly.Core
{
    public class Entity : IEntity
    {
        public string Id { get; set; }
        public DateTime UpdatedTime { get; set;  }
        public DateTime CreatedTime { get; set; }

        public Dictionary<string, string> CustomFields { get; private set; }

        public Entity()
        {
            CustomFields = new Dictionary<string, string>();
        }    
    }
}
    