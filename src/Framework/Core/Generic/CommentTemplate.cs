using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic
{
    /// <summary>
    /// The generic comment template for the entity.
    /// It allows you to specify the type for key of the comment <see cref="TKey"/>
    /// and the type for the key of the linked entity <see cref="TEntityId"/>
    /// and the type entity type itself <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TKey">Type for the comment itself</typeparam>
    /// <typeparam name="TEntityId">Entity key type</typeparam>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public class CommentTemplate<TKey,TEntityId,TEntity>
    {
        /// <summary>
        /// Comment key. If used in the EF it will also have the Identity property if used for the model creation.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        /// <summary>
        /// The User who left the comment. By default it is Anon.
        /// </summary>
        [DisplayName("User Commented")]
        [DisplayFormat(NullDisplayText = "Anon")]
        public string UserCommented { get; set; }

        /// <summary>
        /// Date when the comment was created.
        /// </summary>
        [Required]
        [DisplayName("Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        /// <summary>
        /// Comment body itself.
        /// </summary>
        [Required]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Entity key to which the comment relates
        /// </summary>
        public virtual TEntityId TargetId { get; set; }
        /// <summary>
        /// Target entity.
        /// </summary>
        public virtual TEntity Target { get; set; }
    }
}