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
    public sealed class ConversationEntityConfig : IEntityTypeConfiguration<ConversationEntity>
    {
        public void Configure(EntityTypeBuilder<ConversationEntity> builder)
        {
            ///////////*********Property******/////////////
            
            builder.HasKey(x => x.Id);

           

            ///////////////**********Index*********/////////////
            
            builder.HasIndex(x => x.Id)
                   .IsUnique();

            //////////////*********Navigation***********///////////

            builder.HasMany(x => x.messageEntities)
                   .WithOne(x => x.conversationEntity)
                   .HasForeignKey(x => x.ConversationId)
                   .IsRequired();

        }
    }
}
