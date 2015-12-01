using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
