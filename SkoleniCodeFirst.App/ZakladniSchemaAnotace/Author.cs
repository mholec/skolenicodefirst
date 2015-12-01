using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkoleniCodeFirst.ZakladniSchemaAnotace.OwnAnnotation;

namespace SkoleniCodeFirst.ZakladniSchemaAnotace
{
    [Table("Authors")]
    public class Author
    {
        public Author()
        {
            AuthorId = Guid.NewGuid();
        }

        public Guid AuthorId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        [Email]
        public string SecondEmail { get; set; }

        public decimal? Fee { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
