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

        public RoleEntity(int id, string? roleName)
        {
            Id = id;
            RoleName = roleName;
        }


        //////////////
        
        public List<AccountEntity> accountEntities { get;  }=new List<AccountEntity>();
        public List<PermissionEntity> permissionEntities { get; }= new List<PermissionEntity>();
        public List<RolePermission>? rolePermission { get; }  = new List<RolePermission>();
    }
}
