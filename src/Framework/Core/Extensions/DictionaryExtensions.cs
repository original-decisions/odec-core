using System.Collections.Generic;
using System.Text;

namespace odec.Framework.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts IEnumerable of KeyValues to KeyValue Pair string
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="items">Enumerable collection of key value pairs</param>
        /// <param name="format">String Format. Default is ( key=vallue )</param>
        /// <param name="separator">KevValue Pair Separator</param>
        /// <returns></returns>
        public static string ToKeyValuePairsString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items, string format = null, char separator = '&')
        {
            format = string.IsNullOrEmpty(format) ? "{0}={1}" + separator : format + separator;

            var itemString = new StringBuilder();
            foreach (var item in items)
                itemString.AppendFormat(format, item.Key, item.Value);

            return itemString.ToString().Trim(separator);
        }
    }
}
