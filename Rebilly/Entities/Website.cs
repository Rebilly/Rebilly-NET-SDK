
namespace Rebilly.Entities
{
    public class Website : Entity
    {
        public string Name { get; set;  }
        public string Url { get; set; }
        public string ServicePhone { get; set; }
        public string ServiceEmail { get; set; }
        public string CheckoutPageUri { get; set; }
        public string WebHookUrl { get; set; }
        public string WebHookUsername { get; set; }
        public string WebHookPassword { get; set; }

    }
}
