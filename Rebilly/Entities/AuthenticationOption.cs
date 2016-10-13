using Rebilly.Core;

namespace Rebilly.Entities
{
    public class AuthenticationOption : Entity
    {
        public string PasswordPattern { get; set; }
        public int CredentialTtl { get; set; }
        public int AuthTokenTtl { get; set; }
        public int ResetTokenTtl { get; set; }
    }
}
