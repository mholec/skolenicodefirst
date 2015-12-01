using System.Data.Entity.ModelConfiguration;
using Dotazovani.Entities;

namespace Dotazovani.Mapping
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
            HasKey(x => x.BookId);
            Property(x => x.Title).IsRequired().HasMaxLength(100);

            HasRequired(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
            HasMany(x => x.ParameterValues).WithRequired(x => x.Book).HasForeignKey(x => x.BookId);//.WillCascadeOnDelete(false);
        }
    }
}
