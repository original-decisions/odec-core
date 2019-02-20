using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace odec.Framework.Generic
{
    public class Image<TKey,TRelationId, TRelation> : Glossary<TKey> where TKey : struct 
    {
        [Required]
        [StringLength(256)]
        public string ImgUrl { get; set; }
        [Required(AllowEmptyStrings = true)]
        [StringLength(126)]
        [DefaultValue("")]
        public string Alt { get; set; }
        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        [DefaultValue("")]
        public string Title { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsStretched { get; set; }

        [Required]
        public TRelationId RelationId { get; set; }
        public TRelation Relation { get; set; }
        




    }
}
