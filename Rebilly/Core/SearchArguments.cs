using System.Collections.Generic;

namespace Rebilly.Core
{
    public class SearchArguments
    {
        public SearchArguments()
        {
            Limit = int.MinValue;
            Offset = int.MinValue;

            Sort = new List<string>();
            Fields = new List<string>();
            Filter = new SearchFilter();
        }

        public int Limit { get; set; }
        public int Offset { get; set; }

        public List<string> Sort { get; private set;  }
        public List<string> Fields { get; private set;  }
        public SearchFilter Filter { get;  set;  }
        
    }
}
