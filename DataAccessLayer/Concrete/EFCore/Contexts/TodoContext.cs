using DataAccessLayer.Concrete.EFCore.Mapping;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Contexts
{
    public class TodoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress01;database=udemyJobTracking;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorksMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Work> work { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<Urgency> urgencies { get; set; }
        public DbSet<Report> reports { get; set; }
      
      
    }
}
