using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserConversation : BaseEntity<Guid>,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid InboxId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }


        public UserEntity? userEntity { get; set; }
        public ConversationEntity? conversationEntity { get; set; }
       
    }
}
