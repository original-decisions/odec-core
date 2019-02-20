using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Обобщенный класс - баннер
    /// </summary>
    /// <typeparam name="TKey">Тип идентификтаора</typeparam>
    /// <typeparam name="TNavigation">Тип навигации</typeparam>
    public class BannerGeneric<TKey, TNavigation> : Image<TKey, TNavigation> where TKey : struct 
    {
        /// <summary>
        /// Идентификтаор навигации
        /// </summary>
        public TKey NavigationId { get; set; }
        /// <summary>
        /// Навигация TODO:Возможно стоит понятней назвать, вообще не понятно что это такое
        /// </summary>
        public TNavigation Navigation { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [StringLength(255)]
        public override string Name { get; set; }
    }
}
