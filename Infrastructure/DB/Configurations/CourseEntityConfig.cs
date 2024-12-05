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
    public sealed class CourseEntityConfig : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            ///////////**********property*********/////////////
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(255);

            builder.Property(x => x.Duration)
                    .HasDefaultValue(0);

            builder.Property(x=>x.IsSale)
                   .HasDefaultValue(false);

           

            ///////*******Index********///////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();

            builder.HasIndex(x => x.Name);

            ////////*******Navigation*****/////////

            builder.HasMany(x => x.categoryLessons)
                   .WithOne(x => x.courseEntity)
                   .HasForeignKey(x => x.CourseId)
                   .IsRequired();

            builder.HasMany(x => x.documentEntities)
                   .WithOne(x => x.courseEntity)
                   .HasForeignKey(x => x.CourseId)
                   .IsRequired();

           builder.HasMany(x=>x.cartEntities)    
                  .WithOne(x => x.courseEntity) 
                  .HasForeignKey(x=>x.CouresId)
                  .IsRequired();

            builder.HasMany(x => x.topicEntities)
                   .WithMany(x => x.courseEntities)
                   .UsingEntity<CourseTopic>(
                        l=>l.HasOne(x=>x.topicEntity).WithMany(x=>x.courseTopics).HasForeignKey(x=>x.TopicId),
                        r=>r.HasOne(x=>x.courseEntity).WithMany(x=>x.courseTopics).HasForeignKey(x=>x.CourseId)
                    );

            builder.HasMany(x=>x.tagEntities)
                    .WithMany(x=>x.courseEntities)
                    .UsingEntity<CourseTag>(
                        l => l.HasOne(x => x.tagEntity).WithMany(x => x.courseTags).HasForeignKey(x => x.TagId),
                        r => r.HasOne(x => x.courseEntity).WithMany(x => x.courseTags).HasForeignKey(x => x.CourseId)
                    );

            

            builder.HasMany(x => x.paymentEntities)
                   .WithOne(x => x.courseEntity)
                   .HasForeignKey(x => x.CourseId)
                   .IsRequired();
            
            builder.HasMany(x=>x.purchaseEntities)
                    .WithOne(x=>x.courseEntity)
                    .HasForeignKey(x=>x.CourseId)
                    .IsRequired();

            builder.HasMany(x=>x.feedbackEntities)
                .WithOne(x=>x.courseEntity)
                .HasForeignKey(x=> x.CourseId)
                .IsRequired();

            builder.HasMany(x=>x.lessonsEntities)
                .WithOne(x=>x.courseEntity)
                .HasForeignKey(x=>x.CourseId)
                .IsRequired();

        }
    }
}
