using System.Collections.Generic;

namespace Rebilly.Core
{
    public class SearchFilter
    {
        public SearchFilter()
        {
            Values = new List<string>();
        }

        public string Field { get; set;  }
        public List<string> Values { get; set; }
    }
}
