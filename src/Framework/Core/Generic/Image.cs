using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic
{
    /// <summary>
    /// Generic Image declaration specifying the image Id with a type<see cref="TKey"/> and Relation object with a type <see cref="TRelationId"/>
    /// also it gives you to specify type <see cref="TRelation"/>of navigation property for the relation.
    /// </summary>
    /// <typeparam name="TKey">Type for the image key</typeparam>
    /// <typeparam name="TRelationId">Type for the relation foreign key or relation key</typeparam>
    /// <typeparam name="TRelation"> Relation navigation property type.</typeparam>
    public class Image<TKey, TRelationId, TRelation> : Glossary<TKey> where TKey : struct
    {
        /// <summary>
        /// URl to the image. Limited with 256 symbols and is required to be filled in.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ImgUrl { get; set; }
        /// <summary>
        /// Alt for the image. It is strongly recommended to fill it in for
        /// SEO purposes and also for the people with impaired reading. String limit is 126 symbols and default value is empty string.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(126)]
        [DefaultValue("")]
        public string Alt { get; set; }
        /// <summary>
        /// Title attribute for the image. It is required and the title length is limited to 500 symbols and is default to empty string.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        [DefaultValue("")]
        public string Title { get; set; }

        /// <summary>
        /// Specifies if the image should be stretched. It is true by default. 
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool IsStretched { get; set; }

        /// <summary>
        /// Entity key which is related to the image
        /// </summary>
        [Required]
        public TRelationId RelationId { get; set; }
        /// <summary>
        /// Relation navigation property.
        /// </summary>
        public TRelation Relation { get; set; }





    }
}
