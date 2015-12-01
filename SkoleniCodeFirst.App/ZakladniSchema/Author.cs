using System;

namespace SkoleniCodeFirst.ZakladniSchema
{
    public class Author
    {
        public Author()
        {
            AuthorId = Guid.NewGuid();
        }

        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Fee { get; set; }
    }
}
