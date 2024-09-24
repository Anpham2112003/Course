using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

       

        /////////////////////////////////////////
        
        public RoleEntity? roleEntity { get; set; }
        public PermissionEntity? permissionEntity { get; set; }
    }
}
