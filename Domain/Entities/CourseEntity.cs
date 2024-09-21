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
        public int Duration { get; set; }
        public string? Thumbnail {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }


        ////////////////////////////////////////
        public UserEntity? User { get; set; }
        public List<CategoryLesson> categoryLessons { get; }=new List<CategoryLesson>();
        public List<DocumentEntity> documentEntities { get; }=new List<DocumentEntity>();
        public List<TopicEntity> topicEntities { get; } = new List<TopicEntity>();  
        public List<CourseTopic> courseTopics { get; } = new List<CourseTopic>();
        public List<CartEntity> cartEntities { get; } = new List<CartEntity>();
        
    }
}
