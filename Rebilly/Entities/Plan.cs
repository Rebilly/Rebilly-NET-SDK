using System;
using Rebilly.Core;

namespace Rebilly.Entities
{
    public class Plan : Entity
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string RichDescription { get; set; }
        
        public decimal? RecurringAmount { get; set; }
        public string RecurringPeriodUnit { get; set; }
        public int? RecurringPeriodLength { get; set; }
        public decimal? TrialAmount { get; set; }
        public string TrialPeriodUnit { get; set; }
        public int? TrialPeriodLength { get; set; }
        public decimal? SetupAmount { get; set; }
        public DateTime? ExpireTime { get; set; }

        public string ContractTermUnit { get; set; }
        public int? ContractTermLength { get; set; }
        public int? RecurringPeriodLimit { get; set; }

        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
    }
}
