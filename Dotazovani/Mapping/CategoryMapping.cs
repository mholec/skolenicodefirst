using System.Data.Entity.ModelConfiguration;
using Dotazovani.Entities;

namespace Dotazovani.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(x => x.CategoryId);
            Property(x => x.Name).IsRequired().HasMaxLength(50);

            HasMany(x => x.Books).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId);
            HasOptional(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
        }
    }
}