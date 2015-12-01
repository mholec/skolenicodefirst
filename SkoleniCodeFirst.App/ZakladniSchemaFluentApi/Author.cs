using System;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
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
        public string Email { get; set; }
        public string SecondEmail { get; set; }
        public decimal? Fee { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
