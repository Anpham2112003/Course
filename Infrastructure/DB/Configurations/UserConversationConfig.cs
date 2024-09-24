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
    public sealed class UserConversationConfig : IEntityTypeConfiguration<UserConversation>
    {
        public void Configure(EntityTypeBuilder<UserConversation> builder)
        {
            builder.HasKey(x => x.MegerId);

            builder.HasIndex(x => x.MegerId)
                   .IsUnique();

        }
    }
}
