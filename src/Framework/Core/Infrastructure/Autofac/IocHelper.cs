using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core.Registration;
using odec.Framework.Logging;

namespace odec.Framework.Infrastructure.Autofac
{
    /// <summary>
    /// Helper for using Autofact Container 
    /// </summary>
    public static class IoCHelper
    {
        /// <summary>
        /// Autofac Container 
        /// </summary>
        public static IContainer Container { get; set; }
        /// <summary>
        /// Gets object registered in Container 
        /// </summary>
        /// <typeparam name="T">type of an object required</typeparam>
        /// <param name="ctrParams">parameters to pass to object of a type T registered in container</param>
        /// <returns>Object from Container</returns>
        public static T GetObject<T>(params object[] ctrParams)
        {
            try
            {
                var tParams =
                    ctrParams.Select(
                            ctrParam =>
                                new TypedParameter(ctrParam.GetType(), ctrParam))
                        .ToList();
                return Container.Resolve<T>(tParams);
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Gets object registered in Container 
        /// </summary>
        /// <typeparam name="T">type of an object required</typeparam>
        /// <param name="takeBase">take base clases for parameters passed to constructor 
        /// (for extensability purposes. ex: to pass DbContext instead of concrete context, so our Repositories can use any context with specific objects discribed  )
        /// </param>
        /// <param name="ctrParams">parameters to pass to object of a type T registered in container</param>
        /// <returns>Object from Container</returns>
        public static T GetObject<T>(bool takeBase, params object[] ctrParams)
        {
            try
            {
                var tParams =
                    ctrParams.Select(
                            ctrParam =>
                                new TypedParameter(
                                    takeBase ? ctrParam.GetType().GetTypeInfo().BaseType : ctrParam.GetType(), ctrParam))
                        .ToList();
                return Container.Resolve<T>(tParams);
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }

        }
    }
}
