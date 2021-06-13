using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Mapping
{
  public  class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasMaxLength(200).IsRequired(true);
            builder.HasOne(I => I.appUser).WithMany(I => I.Notifications).HasForeignKey(I => I.AppUserId);
        }

    
    }
}
