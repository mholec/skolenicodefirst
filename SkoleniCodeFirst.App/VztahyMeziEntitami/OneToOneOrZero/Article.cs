using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public ArticleMetadata Metadata { get; set; }
    }
}
