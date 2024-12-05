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
    public sealed class CommentEntityConfig : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            ////////*********Property**********//////////
            builder.HasKey(x=> x.Id);


            builder.Property(x => x.Content)
                   .HasMaxLength(255);



            /////////////**********Index*********/////////
            ///
            //////////*******Navigation********////////

        }
    }
}
