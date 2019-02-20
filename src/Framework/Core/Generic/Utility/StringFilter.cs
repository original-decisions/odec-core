using odec.Framework.Infrastructure.Enumerations;

namespace odec.Framework.Generic.Utility
{
    /// <summary>
    /// String Filter Helper for most used cases.
    /// </summary>
    public class StringFilter
    {
        string[] _symbols = new string[] { "%", "*" };

        /// <summary>
        /// Default String comparison - Contains
        /// </summary>
        public StringFilter()
        {
            CompareOperation = StringCompareOperation.Contains;
        }
        /// <summary>
        /// Default String comparison - Contains
        /// </summary>
        public StringFilter(string target):this()
        {
            Target = target;
        }
        /// <summary>
        /// Target String
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// Compare Operation
        /// </summary>
        public StringCompareOperation CompareOperation { get; set; }
        /// <summary>
        /// RegExp pattern. Works only with RegExp Compare Operation Type
        /// </summary>
        public string RegExPattern { get; set; }
    }
}
