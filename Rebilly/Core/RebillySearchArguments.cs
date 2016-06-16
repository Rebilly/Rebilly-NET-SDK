
namespace Rebilly.Core
{
    public class RebillySearchArguments
    {
        public RebillySearchArguments()
        {
            Limit = int.MinValue;
            Offset = int.MinValue;
            Sort = string.Empty;
        }

        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Sort { get; set;  }
    }
}
