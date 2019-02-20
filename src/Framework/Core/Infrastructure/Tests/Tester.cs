using System;
using Common.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using odec.Framework.Logging;

namespace odec.Framework.Infrastructure.Tests
{
    /// <summary>
    /// base class for all EF Tests
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class Tester<TContext>
        where TContext: DbContext
    {
        /// <summary>
        /// Logger
        /// </summary>
        protected ILog Logger { get { return LogEventManager.Logger; } }
        /// <summary>
        /// Connection String
        /// </summary>
        protected string ConnectionString { get; set; }
        /// <summary>
        /// Db Context
        /// </summary>
        protected TContext Context { get; set; }
        /// <summary>
        /// Initialazor for NUnit.framework 
        /// </summary>
        [OneTimeSetUp]
        public virtual void Init()
        {
            try
            {
                LogEventManager.Init();
                ConnectionString = ConnectionManager.TestConnection;
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex.Message, ex);
                throw;
            }
        }


    }
}
