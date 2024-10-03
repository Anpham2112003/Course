using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class RolesData
    {
        public static readonly List<RoleEntity> roleEntities = new List<RoleEntity>()
        {
                new RoleEntity
                {
                    RoleName="User"
                },

                new RoleEntity
                {
                    RoleName="Lecturer"
                },

                new RoleEntity
                {
                    RoleName="Admin"
                }
        };
       
    }
}
