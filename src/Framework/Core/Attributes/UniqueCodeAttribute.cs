using System;

namespace odec.Framework.Attributes
{
    /// <summary>
    /// Unique code attribute is used to give some additional metadata to class. Example of use to give some extended properties for the enum constants such as String code or description.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class UniqueCodeAttribute:Attribute
    {
        /// <summary>
        /// Unique code for the member marked by the attribute.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Description for the member marked with the attribute.
        /// </summary>
        public string Description { get; set; }
    }
}