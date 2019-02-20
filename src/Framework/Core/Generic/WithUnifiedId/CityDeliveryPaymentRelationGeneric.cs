using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic.WithUnifiedId
{

    /// <summary>
    /// Обобщенная связь города Способа доставки и способа оплаты
    /// </summary>
    /// <typeparam name="TKey">Тип Идентификата</typeparam>
    /// <typeparam name="TCity">Тип Города</typeparam>
    /// <typeparam name="TDelivery">Тип Способа доставки</typeparam>
    /// <typeparam name="TPayment">Тип Способа оплаты</typeparam>
    public class CityDeliveryPaymentRelationGeneric<TKey, TCity,TDelivery, TPayment>
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        [Key,Column(Order = 0)]
        public TKey CityId { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public TCity City { get; set; }
        /// <summary>
        /// Идентификатор Способа доставки
        /// </summary>
        [Key, Column(Order = 1)]
        public TKey DeliveryMethodId { get; set; }
        /// <summary>
        /// Способ доставки
        /// </summary>
        public TDelivery DeliveryMethod { get; set; }
        /// <summary>
        /// Идентификтор Способа оплаты
        /// </summary>
        [Key, Column(Order = 2)]
        public TKey PaymentMethodId { get; set; }
        /// <summary>
        /// Способ оплаты
        /// </summary>
        public TPayment PaymentMethod { get; set; }
        /// <summary>
        /// Стоимость доставки
        /// </summary>
        [Required]
        [DefaultValue(0)]
        public decimal DeliveryCost { get; set; }

    }
}
