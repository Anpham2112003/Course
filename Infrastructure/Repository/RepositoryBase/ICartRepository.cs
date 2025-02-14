﻿using Domain.Entities;
using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ICartRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<CartEntity?> GetCartDetailAsync(Guid id);
        public  Task<TCart?> GetCartById<TCart>(Guid id, CancellationToken cancellation=default);
        public  IQueryable<TCart> GetCartsByUerId<TCart>(Guid Id) where TCart : class, ICart;

    }
}
