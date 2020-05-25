using _Nuevo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _Nuevo.DataAccsess.Concrete.Mapping
{
    public class TargetMap : IEntityTypeConfiguration<Target>
    {
        public void Configure(EntityTypeBuilder<Target> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1);
            builder.Property(u => u.Url).HasMaxLength(200).IsRequired();
        }
    }
}
