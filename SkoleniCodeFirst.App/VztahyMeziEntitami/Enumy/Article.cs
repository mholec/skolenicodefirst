using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.Enumy
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public State State { get; set; }
    }
}
