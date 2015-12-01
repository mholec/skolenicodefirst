using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany
{
    public class Author
    {
        public Author()
        {
            Articles = new List<Article>();
        }

        [Key]
        public int AuthorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
