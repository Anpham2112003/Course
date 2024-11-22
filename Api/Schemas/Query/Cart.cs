using Api.DataLoader;
using AutoMapper;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.ApolloFederation;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Cart : ICart
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CouresId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ReferenceResolver]
        public static async Task<Cart?> GetCart(Guid Id,[Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,[Service] IMapper mapper, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.cartRepository.GetCartById<Cart>(Id,cancellationToken);

            return result;
        }

        public async Task<Course?> GetCourse(GetCourseDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(CouresId,cancellation);
        }
    }
}
