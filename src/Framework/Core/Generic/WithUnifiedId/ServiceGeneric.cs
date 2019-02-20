using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Обобщенный класс - сервис
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    /// <typeparam name="TServiceType">Тип типа сервиса</typeparam>
    /// <typeparam name="TServiceReview">Тип обзора сервиса</typeparam>
    public class ServiceGeneric<TKey, TServiceType, TServiceReview> : Glossary<TKey>
    {
        /// <summary>
        /// Название
        /// </summary>
        [StringLength(200)]
        public override string Name { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        [Required]
        [StringLength(20)]
        public string SerialNumber { get; set; }
        /// <summary>
        /// Идентификатор типа сервиса
        /// </summary>
        [Required]
        public TKey ServiceTypeId { get; set; }
        /// <summary>
        /// ТИп сервиса
        /// </summary>
        public virtual TServiceType ServiceType { get; set; }
        /// <summary>
        /// нижняя цена
        /// </summary>
        [Required]
        public decimal LowerCost { get; set; }
        /// <summary>
        /// верхняя цена
        /// </summary>
        [Required]
        public decimal UpperCost { get; set; }
        /// <summary>
        /// Описание сервиса
        /// </summary>
        [Required]
        [DefaultValue("")]
        [MaxLength(1536)]
        public string Description { get; set; }


        public virtual ICollection<TServiceReview> ServiceReviews { get; set; }
    }
}