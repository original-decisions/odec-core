using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odec.Framework.Generic.WithUnifiedId
{

    /// <summary>
    /// Обобщенный класс - подписка на определеный маршрутизацию( в плане навигации по веб сайту)
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    /// <typeparam name="TSubscriber">Тип подписчика</typeparam>
    /// <typeparam name="TRoute">Тип маршрута</typeparam>
    public class RouteSubscriberGeneric<TKey,TSubscriber,  TRoute>
    {
        /// <summary>
        /// Подписант
        /// </summary>
        public TSubscriber Subscriber { get; set; }
        /// <summary>
        /// Идентификатор подписанта
        /// </summary>
        [Key,Column(Order = 0)]
        public TKey SubscriberId { get; set; }
        /// <summary>
        /// Идентификтаор маршрута
        /// </summary>
        [Key, Column(Order = 1)]
        public TKey RouteId { get; set; }
        /// <summary>
        /// Маршрут
        /// </summary>
        public TRoute Route { get; set; }
    }
}
