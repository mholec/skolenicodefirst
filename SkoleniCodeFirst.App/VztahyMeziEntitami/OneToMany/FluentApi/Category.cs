using System.Collections.Generic;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany.FluentApi
{
    public class Category
    {
        public int CategoryId { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
