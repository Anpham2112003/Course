using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NotificationEntity : BaseEntity<Guid>,ICreated
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ToId { get; set; }
        public string? Content {  get; set; }
        public DateTime CreatedAt { get; set; }
        ////////////////////////////////////////
        ///
        public UserEntity? fromUserEntity { get; set; }
    }

    
}
