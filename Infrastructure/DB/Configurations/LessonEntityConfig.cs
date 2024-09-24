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
    public sealed class LessonEntityConfig : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            //////////////********property******////////////
            
            builder.HasKey(x=> x.Id);

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();

            builder.Property(x=>x.UpdatedAt)
                   .ValueGeneratedOnUpdate();

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            //////////*********Index**********/////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();

            ///////////*********Navigation******//////////

            builder.HasMany(x => x.reportEntities)
                   .WithOne(x => x.lessonEntity)
                   .HasForeignKey(x => x.LessonId)
                   .IsRequired(false);

            builder.HasMany(x=>x.reportEntities)
                    .WithOne(x=>x.lessonEntity)
                    .HasForeignKey(x=>x.LessonId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x=>x.exerciseEntities)
                    .WithOne(x=>x.lessonEntity)
                    .HasForeignKey(x=>x.LessonId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
