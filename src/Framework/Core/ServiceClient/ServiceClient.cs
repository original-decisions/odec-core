using System;
using System.ServiceModel;
using odec.Framework.Logging;
namespace odec.Framework.ServiceClient
{
    /// <summary>
    /// Static class - Service Client
    /// </summary>
    /// <typeparam name="T">Type of a service instance</typeparam>
    public sealed class ServiceClient<T>
        where T : class
    {
        private static T _instance;
        // private static readonly ILog Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Service client
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (ServiceLock<T>.Lock)
                {
                    try
                    {
                        if (_instance == null)
                        {
                            //var client = IocHelper.GetObject<T>();
                            //SubscribeServiceEvents(client);
                            //_instance = client;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogEventManager.Logger.Error(ex);
                        throw;
                    }

                    return _instance;
                }
            }
        }

        /// <summary>
        /// Subscription on service events(fault)
        /// </summary>
        /// <param name="client">Service client</param>
        private static void SubscribeServiceEvents(T client)
        {
            ((ICommunicationObject)client).Faulted += ServiceFaulted;
        }

        /// <summary>
        /// Clears Service Instance on fault
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ServiceFaulted(object sender, EventArgs e)
        {
            lock (ServiceLock<T>.Lock)
            {
                _instance = default(T);
               // IocHelper.ContextClear();
            }
        }
    }
}