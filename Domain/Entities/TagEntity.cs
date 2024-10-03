using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TagEntity : BaseEntity<int>, ICreated,IUpdated
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        /////////////////////////////////////
        public List<CourseEntity> courseEntities { get; set; } = new List<CourseEntity>();
        public List<CourseTag> courseTags { get; set; } = new List<CourseTag>();
        
        
    }
}
