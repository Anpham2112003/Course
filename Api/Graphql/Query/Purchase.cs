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
    public class Purchase : IPurchase
    {
       
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreatedAt { get; set; }

       
    
        public async Task<Course?> GetCourse(GetCourseDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(CourseId, cancellation);
        }
    }
}
