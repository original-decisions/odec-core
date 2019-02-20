using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// обобщенный класс связи товара и услуги(сервиса)
    /// </summary>
    /// <typeparam name="TKey">Тим идентификтора</typeparam>
    /// <typeparam name="TGood">Тип товара</typeparam>
    /// <typeparam name="TService">Тип услуги(сервиса)</typeparam>
    public class ServiceGoodGeneric<TKey, TGood, TService>
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Key, Column(Order = 1)]
        public TKey GoodId { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public TGood Good { get; set; }
        /// <summary>
        /// Идентификатор услуги(сервиса)
        /// </summary>
        [Key,Column(Order = 0)]
        public TKey ServiceId { get; set; }
        /// <summary>
        /// Услуга(сервис)
        /// </summary>
        public TService Service { get; set; }
    }
}
