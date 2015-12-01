using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.Enumy.BestPractice
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }

        [ForeignKey("State")]
        public State StateId { get; set; }
        
        public ArticleState State { get; set; }
    }
}
