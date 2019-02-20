using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic
{
    /// <summary>
    /// Typical Glossary Object 
    /// </summary>
    /// <typeparam name="T">Key(Identity) type (int, guid, string, etc)</typeparam>
    public class Glossary<T> //where T : struct
    {
        /// <summary>
        /// Default constructor. Is Active: true, Date Updated/Created: Now
        /// </summary>
        public Glossary()
        {
            IsActive = true;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        /// <summary>
        /// Identity
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public virtual string Name { get; set; }
        /// <summary>
        /// Unique System Code
        /// </summary>
        [Required]
        [StringLength(128)]
        public virtual string Code { get; set; }
        
        /// <summary>
        /// Is active flag
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        /// <summary>
        /// Sort order
        /// </summary>
        [Required]
        [DefaultValue(0)]
        public int SortOrder { get; set; }

        /// <summary>
        /// Date when row was updated
        /// </summary>
        [Required]
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// Date when row was created
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

    }
}