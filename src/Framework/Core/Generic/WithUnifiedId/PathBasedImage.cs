using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Изображение, которое хранится по какому-то пути
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public class PathBasedImage<TKey>: Image<TKey> where TKey : struct
    {
        /// <summary>
        /// Путь к изображению
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Path { get; set; }
    }
}
