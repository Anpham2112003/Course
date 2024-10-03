using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB.Configurations
{
    public sealed class ReportEntityConfig : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            //////////*******Property********/////////////
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasMaxLength(255);


            //////////////*******Index******//////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();
                   
        }
    }
}
