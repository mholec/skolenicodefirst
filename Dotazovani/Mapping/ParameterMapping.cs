using System.Data.Entity.ModelConfiguration;
using Dotazovani.Entities;

namespace Dotazovani.Mapping
{
    public class ParameterMapping : EntityTypeConfiguration<Parameter>
    {
        public ParameterMapping()
        {
            HasKey(x => x.ParameterId);
            Property(x => x.Name).IsRequired().HasMaxLength(50);

            HasMany(x => x.Values).WithRequired(x => x.Parameter).HasForeignKey(x => x.ParameterId);
        }
    }
}