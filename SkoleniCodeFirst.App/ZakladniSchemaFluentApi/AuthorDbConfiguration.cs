using System.Data.Entity.ModelConfiguration;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
{
    public class AuthorDbConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorDbConfiguration()
        {
            this.ToTable("Authors");
            this.HasKey(x => x.AuthorId);

            this.Property(x => x.FirstName).HasMaxLength(50);
            this.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            this.Property(x => x.Email).IsRequired();
            this.Property(x => x.Fee).HasPrecision(18, 2);
            this.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
