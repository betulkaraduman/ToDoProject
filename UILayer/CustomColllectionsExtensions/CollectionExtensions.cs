using BusinessLayer.Concrete;
using BusinessLayer.Interfaces;
using BusinessLayer.ValidationRules.ValidationRules;
using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using DTOService.DTOs.AppUserDTOs;
using DTOService.DTOs.ReportDTOs;
using DTOService.DTOs.UrgencyDTOs;
using DTOService.DTOs.WorkDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.CustomColllectionsExtensions
{
    public static class CollectionExtensions
    {
        public static void AddCustomerIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false; opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
            })
                   .AddEntityFrameworkStores<TodoContext>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "JobTracking";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }
        public static void AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<RegisterDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<LoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();


        }
    }

}
