using Domain.Schemas;
using HotChocolate;
using HotChocolate.ApolloFederation;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class CategoryLesson : ICategoryLesson
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ReferenceResolver]
        public static async Task<CategoryLesson?> GetCategoryLesson(Guid id, [Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.categoryLessonRepository.GetCategoryLessonById<CategoryLesson>(id,cancellation);
        }

        public async Ta
    }
}
