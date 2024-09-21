using Domain.Enums;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountEntity : BaseEntity<Guid>, ICreated, IUpdated, ISoftDeleted
    {
        public Guid Id { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }
        public string? HashPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }
        public EnumLogin LoginType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        ////////////////////////////////////////////
        

        public UserEntity? userEntity { get; set; }
        public RoleEntity? roleEntity { get; set; }
    }
}
