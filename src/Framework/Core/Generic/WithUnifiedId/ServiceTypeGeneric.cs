using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// ОБобщенный класс -типа услуги
    /// </summary>
    /// <typeparam name="TKey">Тип идентификтора</typeparam>
    public class ServiceTypeGeneric<TKey> : Glossary<TKey>
    {
        /// <summary>
        /// Имя
        /// </summary>
        [StringLength(150)]
        public override string Name { get; set; }

    }
}
