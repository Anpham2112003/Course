using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class PermissionData
    {
        public static readonly List<PermissionEntity> permissions = new List<PermissionEntity>
        {
            new PermissionEntity
            {
                Route="getUserById",
                State=true,
            }
        };
    }
}
