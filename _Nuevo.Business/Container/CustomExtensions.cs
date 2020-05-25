using _Nuevo.Business.Concrete;
using _Nuevo.Business.CustomLogger;
using _Nuevo.Business.Interfaces;
using _Nuevo.DataAccsess.Concrete.Repositories;
using _Nuevo.DataAccsess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace _Nuevo.Business.Container
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITargetService, TargetManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IStatuService, StatuManager>();
            services.AddScoped<ITargetDal, EfTargetRepository>();
            services.AddScoped<IStatuDal, EfStatuRepository>();
            services.AddScoped<IUserDal, EfUserRepository>();
            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
