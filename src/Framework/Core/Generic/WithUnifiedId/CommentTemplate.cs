using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Обобщенный класс - шаблонных комментариев
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    /// <typeparam name="TEntity">Тип Сущности</typeparam>
    /// <typeparam name="TUser">Тип пользователя</typeparam>
    public class CommentTemplate<TKey, TEntity, TUser>
    {
        /// <summary>
        /// Скрытое поле - дата создания
        /// </summary>
        private DateTime _dateCreated = DateTime.Now;

        private DateTime _dateUpdated = DateTime.Now;

        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [DisplayName("Комментарий от")]
        [DisplayFormat(NullDisplayText = "Анонимус")]
        public TKey UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public TUser User { get; set; }
        /// <summary>
        /// Дата создания комментария
        /// </summary>
        [Required]
        [DisplayName("Дата создания комментария")]
        public DateTime DateCreated { get { return this._dateCreated; } set { this._dateCreated = value; } }
        /// <summary>
        /// Дата обновления(редактирования)
        /// </summary>
        public DateTime DateUpdated { get { return this._dateUpdated; } set { this._dateUpdated = value; } }
        /// <summary>
        /// Сам комментарий
        /// </summary>
        [Required]
        [DisplayName("Комментарий")]
        public string Comment { get; set; }

        /// <summary>
        /// Идентификатор ссылки на сущность
        /// </summary>
        public virtual TKey TargetId { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual TEntity Target { get; set; }
    }
}