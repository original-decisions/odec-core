using System.IO;
using System.Text;

namespace odec.Framework.Extensions
{
    /// <summary>
    /// Useful extensions to work with strings. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert string to the <see cref="Stream"/> with default encoding (<see cref="UTF8Encoding"/>)
        /// </summary>
        /// <param name="value">string to be converted to <see cref="Stream"/> object </param>
        /// <returns><see cref="Stream"/> object from the initial string.</returns>
        public static Stream ToStream(this string value)
        {
            return ToStream(value, Encoding.UTF8);
        }

        /// <summary>
        /// Convert string to the <see cref="Stream"/> with encoding specified in the <paramref name="encoding"/>
        /// </summary>
        /// <param name="value">string to be converted to <see cref="Stream"/> object </param>
        /// <param name="encoding">Encoding which the </param>
        /// <returns><see cref="Stream"/> object from the initial string. </returns>
        public static Stream ToStream(this string value, Encoding encoding)
        {
            return new MemoryStream(encoding.GetBytes(value ?? string.Empty));
        }
    }
}
