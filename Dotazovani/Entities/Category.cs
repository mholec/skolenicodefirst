using System.Collections.Generic;

namespace Dotazovani.Entities
{
    public class Category
    {
        // pk
        public int CategoryId { get; set; }

        // fk
        public int? ParentId { get; set; }

        // properties
        public string Name { get; set; }
        
        // navigation properties
        public Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}