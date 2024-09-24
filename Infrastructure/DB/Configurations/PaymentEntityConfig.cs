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
    public sealed class PaymentEntityConfig : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            //////////////////***********Property***********/////////////
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                   .ValueGeneratedOnAdd();

            /////////////*********Index*******/////////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();
        }
    }
}
