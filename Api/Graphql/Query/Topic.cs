using Api.DataLoader;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Topic : ITopic
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }

        

        public async Task<int> TotalCourse([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.topicRepository.CountCourseByTopicId(Id,cancellation);
        }

        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return unitOfWork.topicRepository.GetCoursesByTopicId<Course>(Id);
        }
    }
}
