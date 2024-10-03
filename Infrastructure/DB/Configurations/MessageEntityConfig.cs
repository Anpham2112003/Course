using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class MessageEntityConfig : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            /////////////*******Property**********///////////
            builder.HasKey(x=>x.Id);


            builder.Property(x => x.Content)
                   .HasMaxLength(255);

           

            ///////*******Index********/////////
            
            builder.HasIndex(x=>x.Id)
                   .IsUnique();
        }
    }
}
