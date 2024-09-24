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
    public sealed class CategoryLessonEntityConfig : IEntityTypeConfiguration<CategoryLessonEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryLessonEntity> builder)
        {
            //////////*******property******////////
            
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();

            builder.Property(x=>x.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.Property(x=>x.IsDeleted)
                   .HasDefaultValue(false);

            /////////////*************Index********//////////////
            
            builder.HasIndex(x=>x.Id)
                    .IsUnique();

            ///////////********Navigation******///////////
            
            builder.HasMany(x=>x.lessonEntities)
                   .WithOne(x=>x.categoryLesson)
                   .HasForeignKey(x=>x.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
