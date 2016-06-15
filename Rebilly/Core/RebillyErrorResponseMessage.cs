using System.Collections.Generic;

namespace Rebilly.Core
{
    public class RebillyErrorResponseMessage
    {
        public int Status { get; set; }
        public string Error { get; set; }
        public List<string> Details { get; set;  }

        public string FullMessage
        {
            get
            {
                string FullMessage = string.Format("Client request failed with error status {0}.", Status);

                if(!string.IsNullOrEmpty(Error))
                {
                    FullMessage += "  " + Error;
                }

                if(Details != null)
                {
                    foreach(var detail in Details)
                    {
                        FullMessage += "  " + detail;
                    }
                }

                return FullMessage;
            }
        }

    }
}
