using Common.Logging;
using NUnit.Framework;
using odec.Framework.Generic;
using odec.Framework.Logging;

namespace odec.Framework.CP.Tests
{


    class LoggerTester
    {
        [Test]

        public void DefaultLoggerAndLogging()
        {
            Assert.DoesNotThrow(() => LogEventManager.Logger.Error("ErrorMessage from DefaultLoggerAndLogging"));
        }

        [Test]
        public void SetLoggerAndLog()
        {
            Assert.DoesNotThrow(LogEventManager.SetDefaultLogger<LoggerTester>);
            Assert.DoesNotThrow(() => LogEventManager.Logger.Error("ErrorMessage from SetLoggerAndLog"));
        }

        [Test]
        public void TypedLogger()
        {
            ILog logger = null;
            Assert.DoesNotThrow(() => logger=LogEventManager.GetTypedLogger<Glossary<int>>());
            Assert.NotNull(logger);
            Assert.DoesNotThrow(() => logger.Error("ErrorMessage from TypedLogger"));
        }

        //[Test]
        //public void TestNLogConfig()
        //{

        //}
    }
}
