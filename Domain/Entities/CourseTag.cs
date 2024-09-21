using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseTag
    {
        public Guid CourseId { get; set; }
        public int TagId {  get; set; }
        
    }
}
