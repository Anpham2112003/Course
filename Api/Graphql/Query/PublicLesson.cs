using Api.DataLoader;
using Api.Graphql.Query;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class PublicLesson : ILesson
    {
        public Guid Id { get; set; }
        [GraphQLIgnore]
        public Guid UserId { get; set; }
        [GraphQLIgnore]
        public Guid CategoryLessonId { get; set; }
        public string? Title { get; set; }
        public float Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<Comment> GetComments([Service] IUnitOfWork unitOfWork)
        {
            return unitOfWork.commentRepository.GetCommentByLessonId<Comment>(Id);
        }
        
    }
}
