using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ConversationEntity : BaseEntity<Guid>,ICreated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
       
        ////////////////////////////////
        public List<UserEntity> userEntities { get; } = new List<UserEntity>();
        public List<UserConversation> userConversations { get; } = new List<UserConversation>();
        public List<MessageEntity> messageEntities { get; } = new List<MessageEntity>();
    }
}
