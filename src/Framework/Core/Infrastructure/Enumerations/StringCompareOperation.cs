namespace odec.Framework.Infrastructure.Enumerations
{
    /// <summary>
    /// Specifies which operations you are allowed to do with a string.
    /// </summary>
    public enum StringCompareOperation
    {
        /// <summary>
        /// If two strings are equal.
        /// </summary>
        Equals,
        /// <summary>
        /// If one string contains another.
        /// </summary>
        Contains,
        /// <summary>
        /// If one string is the Prefix of another
        /// </summary>
        Prefix,
        /// <summary>
        /// If one string is a postfix of another
        /// </summary>
        Postfix,
        /// <summary>
        /// If a string matches particular regexp. <see cref="System.Text.RegularExpressions.Regex"/>
        /// </summary>
        RegExp
    }
}