using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LessonEntity : BaseEntity<Guid>,ICreated,IUpdated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryLessonId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int Duration {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        ////////////////////////////////////////
        public UserEntity? UserEntity { get; set; }
        public CategoryLesson? CategoryLesson { get; set; }
        
    }
}
