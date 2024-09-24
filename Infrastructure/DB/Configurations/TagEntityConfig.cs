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
    public class TagEntityConfig : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            ///////////********Property*********////////////
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(64);

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();

            builder.Property(x=>x.UpdatedAt)
                   .ValueGeneratedOnUpdate();

            /////////////*********Index*****///////////
            
            builder.HasIndex(x => x.Id)
                    .IsUnique();
        }
    }
}
