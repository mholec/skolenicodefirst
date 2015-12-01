using System.Data.Entity.ModelConfiguration;
using Dotazovani.Entities;

namespace Dotazovani.Mapping
{
    public class ParameterValueMapping : EntityTypeConfiguration<ParameterValue>
    {
        public ParameterValueMapping()
        {
            HasKey(x => x.ParameterValueId);
            Property(x => x.Value).IsRequired().HasMaxLength(300);

            HasRequired(x => x.Parameter).WithMany(x => x.Values).HasForeignKey(x => x.ParameterId);
            HasRequired(x => x.Book).WithMany(x => x.ParameterValues).HasForeignKey(x => x.BookId);//;.WillCascadeOnDelete(false);
        }
    }
}