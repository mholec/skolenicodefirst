namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero.FluentApi
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }

        public ArticleMetadata Metadata { get; set; }
    }
}
