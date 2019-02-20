using Common.Logging;
using Common.Logging.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace odec.Framework.Logging
{
    /// <summary>
    /// Class for logging 
    /// </summary>
    public static class LogEventManager
    {
        /// <summary>
        /// Proxy object of a logger
        /// </summary>
        public static ILog Logger { get; set; }
        /// <summary>
        /// Type Constructor
        /// </summary>
        static LogEventManager()
        {
            Init();
        }
        /// <summary>
        /// Logger Initialization
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
        public static void SetDefaultLogger<T>()
        {
            Logger = LogManager.GetLogger<T>();
        }

        public static ILog GetTypedLogger<T>()
        {
            return LogManager.GetLogger<T>();
        }

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
