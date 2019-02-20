using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    //TODO:Refactoring needed
    /// <summary>
    /// Обобщенный класс - способ доставки
    /// </summary>
    /// <typeparam name="TKey">Тип Идентификатора</typeparam>
    /// <typeparam name="TOrder">Тип заказа</typeparam>
    public class DeliveryMethodGeneric<TKey, TOrder> :Glossary<TKey>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DeliveryMethodGeneric()
        {
            //Не нужны контакты
            NeedContacts = false;
        }
        /// <summary>
        /// Имя
        /// </summary>
        [StringLength(50)]
        public override string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Required]
        [StringLength(1000)]
        [DefaultValue("")]
        public string Description { get; set; }
        /// <summary>
        /// Флаг- необходимы ли контакты
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool NeedContacts { get; set; }
        /// <summary>
        /// Список заказов с этим способом доставки
        /// </summary>
        public virtual ICollection<TOrder> Orders { get; set; }
    }
}
