
using Api.DataLoader;
using Application.MediaR.Comands.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using Domain.Types.ErrorTypes.Unions.User;

using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Unit0fWork;
using MediatR;

namespace Api.Schemas.Query
{
    [ObjectType]
    public class Queries
    {
        //[UseProjection]
        //[UseFiltering]
        //public IQueryable<AccountEntity> Accounts([Service] ApplicationDBContext dBContext)
        //{
        //    return dBContext.Accounts;
        //}
        public async Task<IUser> getUserById(Guid Id,GetUserDataLoader loader,CancellationToken cancellationToken)
        {
            return await loader.LoadAsync(Id,cancellationToken);
        }

        
        public async Task<Course> getCourseById(Guid Id, GetCourseDataLoader loader, CancellationToken cancellationToken)
        {
            return await loader.LoadAsync(Id,cancellationToken);
        }
        
        
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> getCourses([Service] IUnitOfWork unitOfWork,[Service]IMapper mapper)
        {
            return unitOfWork.QueryableEntity<CourseEntity>().ProjectTo<Course>(mapper.ConfigurationProvider);
        }

        
        
    }
}
