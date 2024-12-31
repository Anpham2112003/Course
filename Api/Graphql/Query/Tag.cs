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
    public class Tag:ITag
    {
      
        public int Id { get; set; }
        public string? Name { get; set; }

      

        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<Course> GetCourses([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return unitOfWork.tagRepository.GetCoursesByTagId<Course>(Id);
        }

        public async Task<int> TotalCourse([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.tagRepository.CountCourseByTag(Id, cancellation);
        } 
    }
}
