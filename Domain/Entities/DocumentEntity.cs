using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DocumentEntity : BaseEntity<Guid>, ICreated, IUpdated
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public string? Title {  get; set; }
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        ///////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public CourseEntity? courseEntity { get; set; }

    }
}
