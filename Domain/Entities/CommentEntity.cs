using Domain.Interfaces.EntityBase;
using Domain.Types.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentEntity : BaseEntity<Guid>,ICreated,IUpdated,ISoftDeleted
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ReplyCommentId { get; set; }
        public Guid LessonId { get; set; }
        public string? Content {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        /////////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public LessonEntity? lessonEntity { get; set; }
    }
}
