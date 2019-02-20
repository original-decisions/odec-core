using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic
{
    public class CommentTemplate<T,TEntityId,TEntity>
    {
        private DateTime _dateCreated = DateTime.Now;
        
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        //[Required]
        [DisplayName("Комментарий от")]
        [DisplayFormat(NullDisplayText = "Анонимус")]
        //[DefaultValue(" ")]
        
        public string UserCommented { get; set; }
        [Required]
        [DisplayName("Дата создания комментария")]
        public DateTime DateCreated { get { return this._dateCreated; } set { this._dateCreated = value; } }

        [Required]
        [DisplayName("Комментарий")]
        public string Comment { get; set; }

        
        public virtual TEntityId TargetId { get; set; }
        public virtual TEntity Target { get; set; }
    }
}