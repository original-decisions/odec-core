using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace odec.Framework.Extensions
{

    /// <summary>
    /// LINQ order by extensions. They are allowing you to filter the query by the particular name of the field. 
    /// </summary>
    /// <example>You want to filter by Name property:
    /// <code>var query = query.OrderBy("Name")</code>
    /// will do the job.
    /// </example>
    public static class LinqExtensions
    {
        /// <summary>
        /// Extension method to order the query by the particular property name <paramref name="ordering"/> the order by order is ascending.
        /// </summary>
        /// <typeparam name="T">Query Type</typeparam>
        /// <param name="source">source query which we want to order.</param>
        /// <param name="ordering">field name by which you want to order.</param>
        /// <param name="values">additional values to be passed in the query [!NOTE] (currently not used)</param>
        /// <returns>Ordered ascending query by the field name in <paramref name="ordering"/> </returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), "OrderBy",
                    new[] { type, property.PropertyType }, source.Expression,
                    Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

        /// <summary>
        /// Extension method to order the query by the particular property name <paramref name="ordering"/> the order by order is descending.
        /// </summary>
        /// <typeparam name="T">Query Type</typeparam>
        /// <param name="source">source query which we want to order.</param>
        /// <param name="ordering">field name by which you want to order.</param>
        /// <param name="values">additional values to be passed in the query [!NOTE] (currently not used)</param>
        /// <returns>Ordered descending query by the field name in <paramref name="ordering"/> </returns>
        /// <returns></returns>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), "OrderByDescending",
                    new[] { type, property.PropertyType }, source.Expression,
                    Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
