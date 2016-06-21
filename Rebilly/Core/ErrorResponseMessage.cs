using System.Collections.Generic;

namespace Rebilly.Core
{
    public class ErrorResponseMessage
    {
        public int Status { get; set; }
        public string Error { get; set; }
        public List<string> Details { get; set;  }

        public ErrorResponseMessage()
        {
            Details = new List<string>();
        }

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
