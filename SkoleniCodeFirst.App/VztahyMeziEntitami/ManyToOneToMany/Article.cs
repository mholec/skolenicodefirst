using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToOneToMany
{
    public class Article
    {
        public Article()
        {
            AuthorArticles = new List<AuthorArticles>();
        }

        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }

        public ICollection<AuthorArticles> AuthorArticles { get; set; }
    }
}
