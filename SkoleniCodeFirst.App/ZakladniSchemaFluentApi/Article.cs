using System;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
{
    public class Article
    {
        public Article()
        {
            Created = DateTime.Now;
        }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string InternalTitle { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
