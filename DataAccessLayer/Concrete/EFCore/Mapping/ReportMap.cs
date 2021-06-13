using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Mapping
{
    class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Definition).HasMaxLength(200).IsRequired(true);
            builder.Property(I => I.Detail).HasColumnType("ntext");
            builder.HasOne(I => I.work).WithMany(I => I.reports).HasForeignKey(I => I.WorkId);
        }

    
    }
}
