using System;
using System.ComponentModel;
using System.Reflection;
using odec.Framework.Attributes;

namespace odec.Framework.Extensions
{
    /// <summary>
    /// Enum extensions class
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets Enum description from the  <see cref="UniqueCodeAttribute"/> attribute value.
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Get enum Description specified in the <see cref="UniqueCodeAttribute"/></returns>
        public static string GetDescription(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var name = Enum.GetName(type, enumeration);
            if (name == null) return null;
            var field = type.GetField(name);
            if (field == null) return null;
            var attr =
                field.GetCustomAttribute<UniqueCodeAttribute>();
            if (attr != null) return attr.Description;
            var ucAttr = field.GetCustomAttribute<DescriptionAttribute>();
            return ucAttr?.Description;
        }
        /// <summary>
        /// Gets Unique Code Attribute
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Gets the attribute class ( <see cref="UniqueCodeAttribute"/>) for the Enum.</returns>
        private static UniqueCodeAttribute GetCodeAttribute(this Enum enumeration)
        {
             var type = enumeration.GetType();
            var name = Enum.GetName(type, enumeration);
            if (name == null) return null;
            var field = type.GetField(name);
            var attr = field?.GetCustomAttribute<UniqueCodeAttribute>();
            return attr;
        }
        /// <summary>
        /// Gets Code property for enum from its  <see cref="UniqueCodeAttribute"/> attribute
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Unique Code specified in the  <see cref="UniqueCodeAttribute"/></returns>
        public static string GetCode(this Enum enumeration)
        {
            var attr = enumeration.GetCodeAttribute();
            return attr?.Code;
        }
        /// <summary>
        /// Gets <see cref="CodeInfo"/> wrapper from enumeration <see cref="UniqueCodeAttribute"/>
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns><see cref="CodeInfo"/> wrapper</returns>
        public static CodeInfo GetCodeInfo(this Enum enumeration)
        {
            var attr = enumeration.GetCodeAttribute();
            return attr != null
                ? new CodeInfo
                {
                    Description = attr.Description,
                    Code = attr.Code
                } : new CodeInfo();
        }
       
    }
}
