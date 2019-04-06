using Common.Logging;
using Common.Logging.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace odec.Framework.Logging
{
    /// <summary>
    /// Static class wrapper for the logging using the CommonLogging Framework<see href="https://net-commons.github.io/common-logging/"/>
    /// </summary>
    public static class LogEventManager
    {
        /// <summary>
        /// Proxy object for a logger using the common logging framework logger (<see href="https://net-commons.github.io/common-logging/"/>) wrapper <see cref="ILog"/>
        /// </summary>
        public static ILog Logger { get; set; }
        /// <summary>
        /// Type initializer which is calling <see cref="Init"/> method under the hood.
        /// </summary>
        static LogEventManager()
        {
            Init();
        }
        /// <summary>
        /// Logger Initialization.
        /// Looks up the following files in the assembly run location to build initial configuration 
        /// <code>"appsettings.json"</code>
        /// <code>"CommonLoggingCfg.json"</code>
        /// It sets the Initial logger as the "Default Logger" scope.
        /// </summary>
        public static void Init()
        {
            try
            {
                // logger configuration. If failed to configure reset to default logger
                try
                {

                    IConfiguration config = new ConfigurationBuilder()
                                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                         .AddJsonFile("CommonLoggingCfg.json", optional: true, reloadOnChange: true)
                                         // .AddXmlFile("CommonLoggingCfg.xml", optional: true, reloadOnChange: true)
                                         .Build();
                    SetUpLoggerConfig(config);
                    Logger = LogManager.GetLogger("Default logger");
                }
                catch (Exception ex)
                {
                    LogManager.Reset();
                    Logger = LogManager.GetLogger("Default logger");
                    Console.WriteLine(ex);
                }

                //Logger = LogManager.GetCurrentClassLogger();
                
            }
            catch (Exception ex)
            {

                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Sets default typed <see cref="T"/> logger. 
        /// </summary>
        /// <typeparam name="T"> Type provided to construct default typed logger.</typeparam>
        public static void SetDefaultLogger<T>()
        {
            Logger = LogManager.GetLogger<T>();
        }

        /// <summary>
        /// Gets the typed logger from the LogManager.
        /// </summary>
        /// <typeparam name="T">Typed logger requested.</typeparam>
        /// <returns>Wrapped up logger return with the proxy <see cref="ILog"/> interface.</returns>
        public static ILog GetTypedLogger<T>()
        {
            return LogManager.GetLogger<T>();
        }

        /// <summary>
        /// Sets up the logger configuration by the configuration <paramref name="cfg"/> and section name to look up <paramref name="sectionName"/>.
        /// Section  name is set to "CommonLogging" if not provided."
        /// </summary>
        /// <param name="cfg">Application configuration <see cref="IConfiguration"/> to do the lookup for logging config.</param>
        /// <param name="sectionName">section which we want to look up for config. If not provided the section to lookup will be set to "CommonLogging"</param>
        public static void SetUpLoggerConfig(IConfiguration cfg, string sectionName = null)
        {
            if (string.IsNullOrEmpty(sectionName)) sectionName = "CommonLogging";

            LogConfiguration logConfiguration = new LogConfiguration();
            var loggingSection = cfg.GetSection(sectionName);
            if (loggingSection == null) return;
            loggingSection.Bind(logConfiguration);
            LogManager.Configure(logConfiguration);
        }
    }
}
