using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Nuevo.Business.Container;
using _Nuevo.Business.CustomLogger;
using _Nuevo.Business.Interfaces;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.Entities.Concrete;
using _Nuevo.WebUI.CustomCollectionExtension;
using _Nuevo.WebUI.GlobalException.Middleware;
using _Nuevo.WebUI.Scheduler;
using _Nuevo.WebUI.Services;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _Nuevo.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddContainerWithDependencies();
            services.AddDbContext<NuevoContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomIdentity();
            services.AddCustomValidator();
            services.AddMvc().AddNewtonsoftJson();
            services.AddSingleton<ICustomLogger, NLogLogger>();
            services.AddControllersWithViews().AddFluentValidation();
            services.AddSingleton<IHostedService, ScheduleTask>();
            services.AddScoped<IEmailSender, EmailSender>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ICustomLogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler(logger);
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "areas",
                        pattern: "{area}/{controller=home}/{action=Index}/{id?}"
                    );
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=home}/{action=Index}/{id?}"
                    );
                });
        }
    }
}
