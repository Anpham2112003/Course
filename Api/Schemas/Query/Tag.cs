using Api.DataLoader;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.ApolloFederation;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Tag:ITag
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [ReferenceResolver]
        public static async Task<Tag?> GetTag(int id,GetTagDataLoader loader , CancellationToken cancellation)
        {
            return await loader.LoadAsync(id, cancellation);
        }

        public async Task<IEnumerable<Course>> GetCourses([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,int skip,int limit, CancellationToken cancellation)
        {
            return  await unitOfWork.tagRepository.GetCoursesByTagId<Course>(Id, skip, limit, cancellation);
        }

        public async Task<int> TotalCourse([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.tagRepository.CountCourseByTag(Id, cancellation);
        } 
    }
}
