using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.Enumy.BestPractice
{
    public class ArticleState
    {
        [Key]
        public State ArticleStateId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
