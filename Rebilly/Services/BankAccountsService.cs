using Rebilly.Entities;
using Rebilly.Core;

namespace Rebilly.Services
{
    public class BankAccountsService : Service<BankAccount>
    {
        public BankAccountsService() : base() { }
        public BankAccountsService(string dataProviderName) : base(dataProviderName) { }

        protected override string GetMappedEntityName()
        {
            return "bank-accounts";
        }
    }
}
