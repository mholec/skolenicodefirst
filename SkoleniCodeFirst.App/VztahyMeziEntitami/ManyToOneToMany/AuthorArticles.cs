using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToOneToMany
{
    public class AuthorArticles
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public int Priority { get; set; }

        public Author Author { get; set; }
        public Article Article { get; set; }
    }
}
