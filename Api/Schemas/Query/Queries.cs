using Domain.Entities;
using Domain.Types.QueryTypes;
using HotChocolate;
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

        public User GetUsers() => new User();
    }
}
