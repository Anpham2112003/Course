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
    public sealed class AccountEntityConfig : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            //////*********Property**********/////////
            
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.PhoneNumber)
                    .HasMaxLength(32);

            builder.Property(x => x.Email)
                    .HasMaxLength(255);

            builder.Property(x=>x.HashPassword)
                    .HasMaxLength(255);


            /////////////*****Index*******/////////////

            builder.HasIndex(x => x.Id)
                    .IsUnique();

            builder.HasIndex(x=>x.Email)
                    .IsUnique();

            /////////////*****Navigation*******/////////////

            builder.HasOne(x => x.roleEntity)
                    .WithMany(x => x.accountEntities)
                    .HasForeignKey(x => x.RoleId)
                    .IsRequired();

            
        }
    }
}
