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
    public sealed class ExerciseEntityConfig : IEntityTypeConfiguration<ExerciseEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
        {
            ///////////////*********Property*********/////////
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Url)
                   .HasMaxLength(255);

           
            /////////////****Index*******////////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();


        }
    }
}
