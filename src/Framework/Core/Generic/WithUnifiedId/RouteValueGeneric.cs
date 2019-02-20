using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// ОБощенный класс - значения пути(маршрутизация)
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public class RouteValueGeneric<TKey> : Glossary<TKey>
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [StringLength(150)]
        public override string Name { get; set; }
        /// <summary>
        /// значение
        /// </summary>
        [Required]
        public string Value { get; set; }

    }
}
