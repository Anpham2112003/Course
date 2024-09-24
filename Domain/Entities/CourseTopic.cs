using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseTopic
    {
        public Guid CourseId { get; set; }
        public int TopicId { get;set; }
        

        //////////////////
        
        public CourseEntity? courseEntity { get; set; }
        public TopicEntity? topicEntity { get; set; }
    }
}
