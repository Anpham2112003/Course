using Api.DataLoader;
using Api.Graphql.Query;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class PrivateLesson : ILesson
    {
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public Guid UserId { get; set; }

        [GraphQLIgnore] 
        public Guid CourseId { get; set; }

        [GraphQLIgnore]
        public Guid CategoryLessonId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public float Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

       
        public async Task<PublicUser?> GetUser(GetPublicUserDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(UserId, cancellation);
        }

        public async Task<CategoryLesson?> GetCategoryLesson(GetCategoryLessonDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(UserId, cancellation);
        }

        public async Task<Course?> GetCourse(GetCourseDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(CourseId, cancellation);
        }

        [UseOffsetPaging]
        [UseSorting]

        public IQueryable<Comment> GetComments([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return unitOfWork.commentRepository.GetCommentByLessonId<Comment>(Id);
        }
    }
}
