using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PermissionEntity : BaseEntity<int>
    {
        public int Id { get; set; }
        public string? Route { get; set;}
        public bool State {  get; set; }

        //////////////////////////////////
        public List<RoleEntity> roleEntities { get; } = new List<RoleEntity>();
        public List<RolePermission> rolePermissions { get; } = new List<RolePermission>(); 
    
    }
}
