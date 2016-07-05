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
            Filters = new List<SearchFilter>();
        }

        public int Limit { get; set; }
        public int Offset { get; set; }

        public List<string> Sort { get;  set;  }
        public List<string> Fields { get; set;  }
        public List<SearchFilter> Filters { get;  set;  }
        
    }
}
