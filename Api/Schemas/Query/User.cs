using Api.DataLoader;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using GreenDonut;
using HotChocolate;
using HotChocolate.ApolloFederation;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class User : IUser
    {
        
        [Key]
        public Guid id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Avatar { get; set; }
        public bool IsLecturer { get; set; }
        public string? Information { get; set; }
        public DateTime UpdatedAt { get; set; }


        [ReferenceResolver]
        public static async Task<IUser?> GetUser(Guid id,GetUserDataLoader loader)
        {
            return await loader.LoadAsync(id);
        }

        
        public async Task<IEnumerable<Course>> GetCourses(int skip,int take,[Service(ServiceKind.Resolver)]IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.courseRepository.GetCoursesByUserId<Course>(id, skip, take,cancellation);
        }


        public async Task<IEnumerable<Cart>> GetCarts(int skip,int limit ,[Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            
            return await unitOfWork.cartRepository.GetCartsByUerId<Cart>(id, skip, limit, cancellation);
        }
        
        


    }
}
