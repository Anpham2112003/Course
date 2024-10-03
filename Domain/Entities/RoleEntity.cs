using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoleEntity : BaseEntity<int>
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }

        


        //////////////
        
        public List<AccountEntity> accountEntities { get; set; } =new List<AccountEntity>();
        public List<PermissionEntity> permissionEntities { get; set; } = new List<PermissionEntity>();
        public List<RolePermission>? rolePermission { get; set; }  = new List<RolePermission>();
    }
}
