using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.SelfRelace
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> Children { get; set; }
    }
}
