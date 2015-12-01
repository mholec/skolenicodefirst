using System.Collections.Generic;

namespace SkoleniCodeFirst.VztahyMeziEntitami.SelfRelace.FluentApi
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Category> Children { get; set; }
    }
}
