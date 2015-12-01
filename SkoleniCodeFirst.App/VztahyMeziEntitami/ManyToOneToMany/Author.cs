using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToOneToMany
{
    public class Author
    {
        public Author()
        {
            AuthorArticles = new List<AuthorArticles>();
        }

        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AuthorArticles> AuthorArticles { get; set; }
    }
}
