using Rebilly.Core;

namespace Rebilly.Entities
{
    public class LeadSource : Entity
    {
        public string CustomerId { get; set; }
        public string Medium { get; set; }
        public string Source { get; set; }
        public string Campaign { get; set; }
        public string Term { get; set; }
        public string Content { get; set; }
        public string Affiliate { get; set; }
        public string SubAffiliate { get; set; }
        public string SalesAgent { get; set; }
        public string ClickId { get; set; }
        public string Path { get; set; }
        public string IpAddress { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
}
