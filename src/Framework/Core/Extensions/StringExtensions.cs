using System.IO;
using System.Text;

namespace odec.Framework.Extensions
{
    public static class StringExtensions
    {
        public static Stream ToStream(this string value)
        {
            return ToStream(value, Encoding.UTF8);
        }

        public static Stream ToStream(this string value, Encoding encoding)
        {
            return new MemoryStream(encoding.GetBytes(value ?? string.Empty));
        }
    }
}
