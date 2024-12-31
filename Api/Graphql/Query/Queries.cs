
using Api.DataLoader;
using Api.Graphql.Query;
using Application.MediaR.Comands.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using Domain.Types.ErrorTypes.Unions.User;

using Domain.Untils;
using GreenDonut;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Api.Schemas.Query
{
    [ObjectType]
    public class Queries
    {
       


        public async Task<PublicUser?> getUserById(Guid Id,GetPublicUserDataLoader loader,CancellationToken cancellationToken)
        {
            return await loader.LoadAsync(Id,cancellationToken);
        }




        [Authorize]
        public async Task<PrivateUser?> getMyProfile([Service] IHttpContextAccessor accessor, [Service] IUnitOfWork unitOfWork ,CancellationToken cancellation)
        {
            var userId = accessor.GetId();

            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentException("not found userId in Claim!");
            }

            return await unitOfWork.userRepository.GetUserById<PrivateUser>(userId,cancellation);
        }


        [Authorize]
        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<Cart> getMyCart([Service] IUnitOfWork unitOfWork, [Service] IHttpContextAccessor accessor)
        {
            var userId = accessor.GetId();

            return  unitOfWork.cartRepository.GetCartsByUerId<Cart>(userId);
        }




        [Authorize]
        [UseOffsetPaging]
        [UseSorting]
        [UseFiltering]
        public  IQueryable<Purchase> getMyPurchase([Service] IUnitOfWork unitOfWork, [Service] IHttpContextAccessor accessor)
        {
            var userId = accessor.GetId();

            return  unitOfWork.purchaseRepository.GetPurchaseByUserId<Purchase>(userId);
        }

        
        public async Task<Course?> getCourseById(Guid Id, GetCourseDataLoader loader, CancellationToken cancellationToken)
        {
            return await loader.LoadAsync(Id,cancellationToken);
        }




        [Authorize]
        public async Task<PrivateLesson?> getLessonById(Guid id,GetLessonDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(id, cancellation);
        }


      

      






        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> getCourses([Service] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return unitOfWork.courseRepository.AsQueryableType<Course>();
        }

       




        [Authorize(Roles = new[] {"Admin"})]
        [UseOffsetPaging]
        public IQueryable<PermissionEntity> getPermissions([Service] ApplicationDBContext context)
        {
            return context.Permissions;
        }

        [Authorize(Roles = new[] { "Admin" })]
        public async Task<IEnumerable<RoleEntity>> getRoles([Service] ApplicationDBContext context,CancellationToken cancellation)
        {
            return await context.Roles.ToListAsync(cancellation);
        } 

        [Authorize]
        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<Payment> getMyPayment([Service] IUnitOfWork unitOfWork,[Service]IHttpContextAccessor accessor)
        {
            var userId = accessor.GetId();

            return unitOfWork.paymentRepository.GetPaymentByUserId<Payment>(userId);
        }


        public async Task<IEnumerable<Tag>> GetTags([Service] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.tagRepository.GetTags<Tag>(cancellation);
        }

        public async Task<IEnumerable<Topic>> GetTopics([Service] IUnitOfWork unitOfWork, CancellationToken cancellation)
        {
            return await unitOfWork.topicRepository.GetTopics<Topic>(cancellation);
        }

        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCoursesByTagId(int Id,[Service] IUnitOfWork unitOfWork)
        {
            return unitOfWork.tagRepository.GetCoursesByTagId<Course>(Id);
        }

        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCoursesByTopicId(int Id,[Service] IUnitOfWork unitOfWork)
        {
            return unitOfWork.topicRepository.GetCoursesByTopicId<Course>(Id);
        }

    }
}
