using BusinessLayer.Concrete;
using BusinessLayer.DiContainer;
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
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UILayer.CustomColllectionsExtensions;

namespace UILayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IWorkService, WorkManager>();
            //services.AddScoped<IAppUserService, AppUserManager>();
            //services.AddScoped<IUrgencyService, UrgencyManager>();
            //services.AddScoped<INotificationService, NotificationManager>();
            //services.AddScoped<IReportService, ReportManager>();
            //services.AddScoped<IFilesManager, FileManager>();

            //services.AddScoped<IWorksDal, EfWorksRepository>();
            //services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            //services.AddScoped<INotificationDal, EfNotificationRepository>();
            //services.AddScoped<IAppUserDal, EfAppUserRepository>();
            //services.AddScoped<IReportDal, EfReportRepository>();


            services.AddContainerWithDepencies();


            services.AddDbContext<TodoContext>();

            //services.AddIdentity<AppUser, AppRole>(opt=> { opt.Password.RequireDigit = false;opt.Password.RequireUppercase = false;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequiredLength = 1;
            //    opt.Password.RequireNonAlphanumeric = false;
            //})
            //    .AddEntityFrameworkStores<TodoContext>();
            //services.ConfigureApplicationCookie(opt =>
            //{
            //    opt.Cookie.Name = "JobTracking";
            //    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
            //    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            //    opt.Cookie.HttpOnly = true;
            //    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            //    opt.LoginPath = "/Home/Index";
            //});
            services.AddCustomerIdentity();
            services.AddAutoMapper(typeof(Startup));
            services.AddValidator();
            //services.AddTransient<IValidator<UrgencyAddDto>,UrgencyAddValidator>();
            //services.AddTransient<IValidator<UrgencyUpdateDto>,UrgencyUpdateValidator>();
            //services.AddTransient<IValidator<RegisterDto>,AppUserAddValidator>();
            //services.AddTransient<IValidator<LoginDto>,AppUserLoginValidator>();
            //services.AddTransient<IValidator<ReportAddDto>,ReportAddValidator>();
            //services.AddTransient<IValidator<ReportUpdateDto>,ReportUpdateValidator>();
            //services.AddTransient<IValidator<UrgencyAddDto>,UrgencyAddValidator>();
            //services.AddTransient<IValidator<UrgencyUpdateDto>,UrgencyUpdateValidator>();
            //services.AddTransient<IValidator<WorkAddDto>,WorkAddValidator>();
            //services.AddTransient<IValidator<WorkUpdateDto>,WorkUpdateValidator>();
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
              
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
