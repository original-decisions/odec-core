using System;
using System.ComponentModel;
using System.Reflection;
using odec.Framework.Attributes;


namespace odec.Framework.Extensions
{
    public static class ObjectModelExtensions
    {

        /// <summary>
        /// Gets Enum description attribute value 
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>description</returns>
        private static string GetEnumDescription(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var name = Enum.GetName(type, enumeration);
            if (name == null) return null;
            var field = type.GetField(name);
            if (field == null) return null;
            var attr = field.GetCustomAttribute<UniqueCodeAttribute>();
            if (attr != null) return attr.Description;
            var ucAttr = field.GetCustomAttribute<DescriptionAttribute>();
            return ucAttr?.Description;
        }
        /// <summary>
        /// Gets Unique Code Attribute
        /// </summary>
        /// <param name="enumeration">current enum</param>
        /// <returns>Unique code attribute</returns>
        private static UniqueCodeAttribute GetEnumCodeAttribute(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var name = Enum.GetName(type, enumeration);
            if (name == null) return null;
            var field = type.GetField(name);
            var attr = field?.GetCustomAttribute<UniqueCodeAttribute>();
            return attr;
        }

        public static string GetDescription<T>(this T target)
        {
            var type = target.GetType();
            if (type.GetTypeInfo().IsEnum)
                return (target as Enum).GetEnumDescription();
            var attr = type.GetTypeInfo().GetCustomAttribute<UniqueCodeAttribute>();
            if (attr != null) return attr.Description;
            var ucAttr = type.GetTypeInfo().GetCustomAttribute<DescriptionAttribute>();
            return ucAttr == null ? null : ucAttr.Description;
        }


        public static void GetCodeAttributeForMember()
        {
            
        }

        private static UniqueCodeAttribute GetCodeAttribute<T>(this T target)
        {

            var type = target.GetType();
            if (type.GetTypeInfo().IsEnum)
               return (target as Enum).GetEnumCodeAttribute();
            var attr = type.GetTypeInfo().GetCustomAttribute<UniqueCodeAttribute>();
            return attr;
        }
        public static string GetCode<T>(this T target)
        {

            var attr = target.GetCodeAttribute();
            return attr?.Code;

        }

        public static CodeInfo GetCodeInfo<T>(this T target)
        {
            var attr = target.GetCodeAttribute();
            return attr != null
                ? new CodeInfo
                {
                    Description = attr.Description,
                    Code = attr.Code
                } : new CodeInfo();

        }
    }
}
