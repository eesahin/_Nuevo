using _Nuevo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _Nuevo.DataAccsess.Concrete.Mapping
{
    public class StatuMap : IEntityTypeConfiguration<Statu>
    {
        public void Configure(EntityTypeBuilder<Statu> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
        }
    }
}
