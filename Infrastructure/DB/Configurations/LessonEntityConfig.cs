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

          

            //////////*********Index**********/////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();

            ///////////*********Navigation******//////////


            builder.HasMany(x=>x.commentEntities)
                .WithOne(x=>x.lessonEntity)
                .HasForeignKey(x=>x.LessonId)
                .IsRequired();
        }
    }
}
