using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using odec.Framework.Extensions.Configuration;

namespace odec.Framework.CP.Tests
{
    public class ConfigurationExtTester: Tester
    {

        [Test]
        public void CheckJsonFromString()
        {
            var stringJsonCfg = "{\"Logging\":{\"IncludeScopes\":true,\"LogLevel\":{\"Default\":\"Debug\",\"System\":\"Information\",\"Microsoft\":\"Information\"}},\"ConnectionStrings\":{\"DefaultConnection\":\"Server = (local); Database = WorkObserver.PortalDb; Trusted_Connection = True; MultipleActiveResultSets = true\"}}";
            IConfiguration cfg = null;
            var builder = new ConfigurationBuilder();
            Assert.DoesNotThrow(() => builder.AddJsonFromString(stringJsonCfg));
            Assert.DoesNotThrow(() => cfg = builder.Build());
            Assert.NotNull(cfg);
            var loggingIncludeScopes = cfg.GetValue<bool>("Logging:IncludeScopes");
            Assert.IsTrue(loggingIncludeScopes);
        }
    }
}
