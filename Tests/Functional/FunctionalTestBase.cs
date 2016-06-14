using Rebilly;

namespace Tests.Functional
{
    public class FunctionalTestBase
    {
        protected Client CreateClient()
        {
            var Config = new TestConfig();
            return new Client(apiKey: Config.RebillyApiKey, baseUrl: Client.SandboxHost);
        }
    }
}
