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
        /// Gets Enum description attribute value 
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>description</returns>
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
            return ucAttr == null ? null : ucAttr.Description;
        }
        /// <summary>
        /// Gets Unique Code Attribute
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Unique code attribute</returns>
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
        /// Gets UniqueCodeAttribute Code property for enum
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Unique Code</returns>
        public static string GetCode(this Enum enumeration)
        {
            var attr = enumeration.GetCodeAttribute();
            return attr !=null?  attr.Code:null;
        }
        /// <summary>
        /// Gets Code Info wrapper for Unique Code Attribute
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Code info wrapper</returns>
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
