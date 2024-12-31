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
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public bool IsSale {  get; set; }
        public int Sale {  get; set; }
        
        public DateTime Expired { get; set; }
        
        public string? Description { get; set; }
        public float Rating { get; set; }
        public float Duration { get; set; }
        public string? Thumbnail {  get; set; }
        public bool IsPublish {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }



        ////////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public List<CategoryLessonEntity> categoryLessons { get; set; } =new List<CategoryLessonEntity>();
        public List<TopicEntity> topicEntities { get; set; } = new List<TopicEntity>();  
        public List<CourseTopic> courseTopics { get; set; } = new List<CourseTopic>();
        public List<TagEntity> tagEntities { get; set; } = new List<TagEntity>();
        public List<CourseTag> courseTags { get; set; } = new List<CourseTag>();
        public List<CartEntity> cartEntities { get; set; } = new List<CartEntity>();
        public List<PaymentEntity> paymentEntities { get; set; } = new List<PaymentEntity>();
        public List<PurchaseEntity> purchaseEntities { get; set; } = new List<PurchaseEntity>();
        public List<FeedbackEntity> feedbackEntities { get; set; }=new List<FeedbackEntity>();
        public List<LessonEntity> lessonsEntities { get; set; }=new List<LessonEntity>();

        

       

    }
}
