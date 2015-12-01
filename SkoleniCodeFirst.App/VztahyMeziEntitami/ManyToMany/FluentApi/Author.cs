using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToMany.FluentApi
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

        [InverseProperty("Authors")]
        public ICollection<Article> Articles { get; set; }
    }
}
