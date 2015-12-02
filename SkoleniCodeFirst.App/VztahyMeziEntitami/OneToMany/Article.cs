using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public string Title { get; set; }


        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
