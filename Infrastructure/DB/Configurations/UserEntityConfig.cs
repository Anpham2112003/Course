using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB.Configurations
{
    public sealed class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            ///////***********property************////////////////
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(128);

            builder.Property(x => x.LastName)
                   .HasMaxLength(128);

            builder.Property(x=>x.FullName)
                    .HasMaxLength(255);

      

            /////////******Index********//////////

            builder.HasIndex(x => x.Id)
                    .IsUnique();

            ////////*********Navigation*******///////////

            builder.HasOne(x => x.accountEntity)
                   .WithOne(x => x.userEntity)
                   .HasForeignKey<UserEntity>(x => x.AccountId)
                   .IsRequired();

            builder.HasMany(x => x.purchaseEntities)
                   .WithOne(x => x.userEntity)
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();

            builder.HasMany(x => x.cartEntities)
                    .WithOne(x => x.userEntity)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired();

            builder.HasMany(x=>x.courseEntities)
                    .WithOne(x=>x.userEntity)
                    .HasForeignKey(x => x.AuthorId)
                    .IsRequired();

         



           

          
            builder.HasMany(x=>x.commentEntities)
                   .WithOne(x=>x.userEntity)
                   .HasForeignKey(x=>x.UserId)
                   .IsRequired();

            builder.HasMany(x => x.paymentEntities)
                   .WithOne(x => x.userEntity)
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();

            builder.HasMany(x => x.lessonsEntities)
                    .WithOne(x => x.userEntity)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired();

            builder.HasMany(x => x.categoryLessonsEntities)
                    .WithOne(x => x.userEntity)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired();

            builder.HasMany(x=>x.commentEntities)
                    .WithOne(x=>x.userEntity)
                    .HasForeignKey(x=>x.UserId)
                    .IsRequired();

           

            builder.HasMany(x => x.feedbackEntities)
                    .WithOne(x=>x.userEntity)
                    .HasForeignKey(x=>x.UserId)
                    .IsRequired();

          
        }
    }
}
