using Api.DataLoader;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.ApolloFederation;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Topic : ITopic
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [ReferenceResolver]
        public static async Task<Topic?> GetTopic(int id, GetTopicDataLoader dataLoader,CancellationToken cancellation)
        {
            return await dataLoader.LoadAsync(id, cancellation);
        }

        public async Task<int> TotalCourse([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.topicRepository.CountCourseByTopicId(Id,cancellation);
        }

        [UseOffsetPaging]
        [UseProjection]
        public IQueryable<Course> GetCourses([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,[Service]IMapper mapper)
        {
            return unitOfWork.QueryableEntity<CourseEntity>().ProjectTo<Course>(mapper.ConfigurationProvider);
        }
    }
}
