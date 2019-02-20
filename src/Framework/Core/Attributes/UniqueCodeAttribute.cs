using System;

namespace odec.Framework.Attributes
{
    /// <summary>
    /// Unique code attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class UniqueCodeAttribute:Attribute
    {
        /// <summary>
        /// Unique code itself
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Usefull description of the code
        /// </summary>
        public string Description { get; set; }
    }
}