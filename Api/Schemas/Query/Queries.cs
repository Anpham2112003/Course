using Domain.Entities;
using Domain.Types.QueryTypes;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Services.UnitOfWorkService;

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

        [Authorize(ApplyPolicy.BeforeResolver,Policy ="test")]
        public User GetUsers() => new User();
    }
}
