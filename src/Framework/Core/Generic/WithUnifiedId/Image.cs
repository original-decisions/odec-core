using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Обобщенный класс - для изображения
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    /// <typeparam name="TRelation">Тип сущности к которой относится</typeparam>
    public class Image<TKey, TRelation> : Glossary<TKey> where TKey : struct 
    {
        /// <summary>
        /// Путь к изображению
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ImgUrl { get; set; }
        /// <summary>
        /// атрибут альт изображения
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(126)]
        [DefaultValue("")]
        public string Alt { get; set; }
        /// <summary>
        /// Название изображения
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        [DefaultValue("")]
        public string Title { get; set; }
        /// <summary>
        /// Флаг- являетс ли изображение растянутым
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool IsStretched { get; set; }
        /// <summary>
        /// Идентификатор сущности к которой это изображение относится
        /// </summary>
        [Required]
        public TKey RelationId { get; set; }
        /// <summary>
        ///  сущность к которой это изображение относится
        /// </summary>
        public TRelation Relation { get; set; }
    }

    /// <summary>
    /// Обобщенный класс - для изображения
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public class Image<TKey> : Glossary<TKey> where TKey : struct
    {
        /// <summary>
        /// атрибут альт изображения
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(126)]
        [DefaultValue("")]
        public string Alt { get; set; }
        /// <summary>
        /// Название изображения
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        [DefaultValue("")]
        public string Title { get; set; }
        /// <summary>
        /// Флаг- являетс ли изображение растянутым
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool IsStretched { get; set; }
        
    }
}
