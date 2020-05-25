using System;
using _Nuevo.Business.ValidationRules.FluentValidation;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.DTO.Objects.AppUserDTOs;
using _Nuevo.DTO.Objects.TagetDTOs;
using _Nuevo.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace _Nuevo.WebUI.CustomCollectionExtension
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredLength = 1;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<NuevoContext>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "_NuevoCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }
        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<TargetAddDto>, TargetAddValidator>();
            services.AddTransient<IValidator<TargetUpdateDto>, TargetUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
        }
    }
}
