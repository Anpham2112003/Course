using Api.DataLoader;
using AutoMapper;
using Domain.Schemas;
using HotChocolate;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Cart : ICart
    {
        
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public Guid UserId { get; set; }

        [GraphQLIgnore]
        public Guid CouresId { get; set; }
        public DateTime CreatedAt { get; set; }

        

        public async Task<Course?> GetCourse(GetCourseDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(CouresId,cancellation);
        }
    }
}
