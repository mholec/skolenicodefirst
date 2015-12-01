namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero.FluentApi
{
    public class ArticleMetadata
    {
        public int ArticleId { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        
        public Article Article { get; set; }   
    }
}