using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.ZakladniSchemaAnotace
{
    public class Article
    {
        public Article()
        {
            Created = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [NotMapped]
        public string InternalTitle { get; set; }

        [MinLength(10)] // není DB constraint ale jen na úrovni modelu
        [MaxLength(20)]
        public string Description { get; set; }
        
        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
