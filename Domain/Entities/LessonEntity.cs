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
        public float Duration {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        ////////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public CategoryLessonEntity? categoryLesson { get; set; }
        public List<ReportEntity> reportEntities { get; } = new List<ReportEntity>();
        public List<ExerciseEntity> exerciseEntities { get; set; } = new List<ExerciseEntity>();
        
    }
}
