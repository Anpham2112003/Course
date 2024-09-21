using Domain.Enums;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity<Guid>,ISoftDeleted,IUpdated
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public bool IsLecturer { get; set; }
        public string? Information {  get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }




        /////////////////////////////////////////////
        public AccountEntity? account { get; set; }
        public List<CourseEntity> courses { get; } = new List<CourseEntity>();
        public List<PurchaseEntity> purchaseEntities { get; } = new List<PurchaseEntity>();
        public List<ConversationEntity> conversationEntities { get; } = new List<ConversationEntity>();
        public List<UserConversation> userConversations { get; } = new List<UserConversation>();
        public List<DocumentEntity> documentEntities {  get; } = new List<DocumentEntity>();
        public List<ExerciseEntity> exerciseEntities { get; } = new List<ExerciseEntity>();
        public List<NotificationEntity> notificationEntities {  get; } = new List<NotificationEntity>();     

    }
}
