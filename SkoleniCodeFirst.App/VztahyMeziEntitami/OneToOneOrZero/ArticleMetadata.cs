using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero
{
    public class ArticleMetadata
    {
        [Key, ForeignKey("Article")]
        public int ArticleId { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        
        public Article Article { get; set; }   
    }
}