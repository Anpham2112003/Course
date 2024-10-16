using Domain.Interfaces.EntityBase;
using Domain.Types.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageEntity : BaseEntity<Guid>,ICreated,IUpdated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ReplyMessageId { get; set; }
        public Guid ConversationId { get; set; }
        public string? Content { get; set; }
        public string? ContentReply { get; set; }
        public EnumMessage MessageType { get; set; }
        public DateTime SeenAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        /////////////////////////////////////
        public UserEntity? userEntity {  get; set; }
        public ConversationEntity?  conversationEntity { get; set; }
        public List<MessageEntity>? messages { get; set; }
    }
}
