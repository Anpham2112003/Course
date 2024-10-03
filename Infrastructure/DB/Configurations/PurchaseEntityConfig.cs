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

    public sealed class PurchaseEntityConfig : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            ////////////*******property*********/////////
            
            builder.HasKey(x => x.Id);


            ////////////**********Index*********/////////
            
            builder.HasIndex(x => x.Id);
        }
    }
}
