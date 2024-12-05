using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    [UnionType]
    public interface ILesson
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryLessonId { get; set; }
        public string? Title { get; set; }
        public float Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
