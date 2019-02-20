namespace odec.Framework.ServiceClient
{
    /// <summary>
    /// Service block class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ServiceLock<T>
    {
        /// <summary>
        /// Blocking object
        /// </summary>
        public static readonly object Lock = new object();
    }
}