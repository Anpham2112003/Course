using Api.DataLoader;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class CategoryLesson : ICategoryLesson
    {
       
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public async Task<Course?> GetCourse(GetCourseDataLoader loader ,CancellationToken cancellation)
        {
            return await loader.LoadAsync(CourseId,cancellation);
        }

        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<PublicLesson> GetLessons([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return  unitOfWork.lessonRepository.GetLessonByCategoryLessonId<PublicLesson>(Id);
        }
    }
}
