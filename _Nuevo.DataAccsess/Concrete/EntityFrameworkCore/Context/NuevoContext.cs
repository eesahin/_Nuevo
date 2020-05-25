using _Nuevo.DataAccsess.Concrete.Mapping;
using _Nuevo.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context
{
    public class NuevoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=NuevoDB;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatuMap());
            builder.ApplyConfiguration(new TargetMap());
            base.OnModelCreating(builder);
        }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Statu> Status { get; set; }
    }
}
