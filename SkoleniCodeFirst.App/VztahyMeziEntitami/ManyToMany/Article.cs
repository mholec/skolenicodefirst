using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToMany
{
    public class Article
    {
        public Article()
        {
            Authors = new List<Author>();
        }

        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }

        [InverseProperty("Articles")]
        public ICollection<Author> Authors { get; set; }
    }
}
