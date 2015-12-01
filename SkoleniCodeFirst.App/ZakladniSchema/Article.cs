using System;

namespace SkoleniCodeFirst.ZakladniSchema
{
    public class Article
    {
        public Article()
        {
            Created = DateTime.Now;
        }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
    }
}
