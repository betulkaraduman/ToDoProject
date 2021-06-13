using BusinessLayer.Concrete;
using BusinessLayer.CustomLogger;
using BusinessLayer.Interfaces;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DiContainer
{
   public static class CustomExtensions
    {
        public static void AddContainerWithDepencies(this IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IFilesManager, FileManager>();

            services.AddScoped<IWorksDal, EfWorksRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddTransient<ICustomLogger, NLogLogger>();

        }
    }
}
