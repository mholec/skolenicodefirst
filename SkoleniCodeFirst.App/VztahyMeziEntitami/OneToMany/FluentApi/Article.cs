namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany.FluentApi
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
