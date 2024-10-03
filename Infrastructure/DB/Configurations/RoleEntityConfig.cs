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
    public sealed class RoleEntityConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            /////////***************property***********/////////
            
            builder.HasKey(x => x.Id);


            builder.Property(x => x.RoleName)
                    .HasMaxLength(16);

            ////////******Navigation*****//////////

            builder.HasMany(x => x.permissionEntities)
                    .WithMany(x => x.roleEntities)
                    .UsingEntity<RolePermission>(
                        l=>l.HasOne(x=>x.permissionEntity).WithMany(x=>x.rolePermissions).HasForeignKey(x=>x.PermissionId),
                        r=>r.HasOne(x=>x.roleEntity).WithMany(x=>x.rolePermission).HasForeignKey(x=>x.RoleId)
                    );

        }   
    }
}
