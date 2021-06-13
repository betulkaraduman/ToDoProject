using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Mapping
{
   public class UrgencyMap : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            //builder.HasKey(I => I.Id);
            //builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Definition).HasMaxLength(200);
            //builder.HasMany(I => I.works).WithOne(I => I.urgency).HasForeignKey(I => I.UrgencyId);
        }

        
    }
}
