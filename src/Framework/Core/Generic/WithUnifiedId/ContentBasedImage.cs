using System.Collections.Generic;

namespace odec.Framework.Generic.WithUnifiedId
{
    /// <summary>
    /// Изображения, которые получются из байт массива
    /// </summary>
    /// <typeparam name="TKey">Тип идетификатора</typeparam>
    public class ContentBasedImage<TKey>:Image<TKey> where TKey : struct
    {
        /// <summary>
        /// Контент(само изображение ввиде байтов)
        /// </summary>
        public IList<byte> Content { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extention { get; set; }
    }
}
