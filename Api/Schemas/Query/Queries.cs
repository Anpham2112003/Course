﻿using Domain.Entities;
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

        public string Hello() => "Xin chao";
    }
}
