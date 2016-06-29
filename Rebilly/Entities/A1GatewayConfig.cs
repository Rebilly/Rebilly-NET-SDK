
namespace Rebilly.Entities
{
    public class A1GatewayConfig : GatewayConfig
    {
        public string MemberId { get; set; }
        public long AVS { get; set; }
        public long Delay { get; set; }
        public string AccountId { get; set; }
        public string Password { get; set; }
    }
}
