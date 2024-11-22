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
    public class Purchase : IPurchase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ReferenceResolver]
        public static async Task<Purchase?> GetPurchase(Guid Id,GetPurchaseDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(Id, cancellation);
        }

        [UseOffsetPaging]
        [UseProjection]
        public IQueryable<Course> GetCourse([Service]IUnitOfWork unitOfWork, [Service] IMapper mapper)
        {
            return unitOfWork.QueryableEntity<CourseEntity>().ProjectTo<Course>(mapper.ConfigurationProvider);
        }
    }
}
