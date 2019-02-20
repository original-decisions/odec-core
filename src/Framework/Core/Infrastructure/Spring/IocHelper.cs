using System;
using System.Collections.Generic;
using System.Linq;
using odec.Framework.Logging;

#if NET452
using Spring.Context;
using Spring.Context.Support;

namespace odec.Framework.Infrastructure.Spring
{
    /// <summary>
    /// Application Context. Wrapper class for Spring Context
    /// </summary>
    public class IocHelper
    {

        /// <summary>
        /// Private field. Proxy object of spring.net App Context
        /// </summary>
        private static IApplicationContext _context;
        /// <summary>
        /// Gets a proxy object of spring.net App Context
        /// </summary>
        public static IApplicationContext Context {get {return _context ?? (_context = ContextRegistry.GetContext()); } } 

        /// <summary>
        /// Clears spring.net context
        /// </summary>
        public static void ContextClear()
        {
            ContextRegistry.Clear();
        }

        /// <summary>
        /// Gets the object from Context
        /// </summary>
        /// <typeparam name="T">Type(or interface) of an object</typeparam>
        /// <returns>Object of a type T</returns>
        public static T GetObject<T>()
        {
            try
            {
                var objects = GetObjects<T>();
                if (objects.Count == 1)
                    return objects.Values.Cast<T>().First();

                if (objects.Count > 1)
                    throw new InvalidOperationException("Несколько объектов указанного интерфейса: " + string.Join(", ", objects.Keys));
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }
            return default(T);
        }

        /// <summary>
        /// Gets an object of a type T
        /// </summary>
        /// <typeparam name="T">Type(or interface) of an object</typeparam>
        /// <param name="args">Args that should be sended to object constructor</param>
        /// <returns>an object of a type T</returns>
        public static T GetObject<T>(params object[] args)
        {
            try
            {
                var names = Context.GetObjectNamesForType(typeof(T)).ToList();
                if (names.Count == 1)
                    return (T)Context.GetObject(names[0], args);

                if (names.Count > 1)
                {
                    //Ищем базовый класс
                    foreach (var obj in names.Select(name => Context.GetObject(name, args)).Where(obj => obj.GetType().BaseType == typeof(object)))
                    {
                        return (T)obj;
                    }

                    throw new InvalidOperationException("Несколько объектов указанного интерфейса: " +
                                                        string.Join(", ", names));
                }
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }

            return default(T);
        }

        /// <summary>
        /// Gets all objects of a type(or interface) T
        /// </summary>
        /// <typeparam name="T">Type(or interface) of an object</typeparam>
        /// <returns>objects of a type(or interface) T</returns>
        public static IDictionary<string, object> GetObjects<T>()
        {
            try
            {
                return Context.GetObjectsOfType(typeof(T));
          
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }
        }

    }
}
#endif