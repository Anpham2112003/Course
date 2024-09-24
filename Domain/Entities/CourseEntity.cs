using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseEntity : BaseEntity<Guid>,ICreated,IUpdated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public int Purchase { get; set; }
        public float Price { get; set; }
        public bool IsSale {  get; set; }
        public int Sale {  get; set; }
        public DateTime Expired { get; set; }
        public string? Description { get; set; }
        public float Rating { get; set; }
        public float Duration { get; set; }
        public string? Thumbnail {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }



        ////////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public List<CategoryLessonEntity> categoryLessons { get; }=new List<CategoryLessonEntity>();
        public List<DocumentEntity> documentEntities { get; }=new List<DocumentEntity>();
        public List<TopicEntity> topicEntities { get; } = new List<TopicEntity>();  
        public List<CourseTopic> courseTopics { get; } = new List<CourseTopic>();
        public List<TagEntity> tagEntities { get; } = new List<TagEntity>();
        public List<CourseTag> courseTags { get; } = new List<CourseTag>();
        public List<CartEntity> cartEntities { get; } = new List<CartEntity>();
        public List<CommentEntity> commentEntities { get; } =new List<CommentEntity>();
        public List<PaymentEntity> paymentEntities { get; } = new List<PaymentEntity>();
        public List<PurchaseEntity> purchaseEntities { get; }= new List<PurchaseEntity>();
    }
}
