using System.Collections.Generic;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany.FluentApi
{
    public class Author
    {
        public Author()
        {
            Articles = new List<Article>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
