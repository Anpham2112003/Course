﻿using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface IPurchaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<bool> CheckPurchaseCourse(Guid UserId, Guid CourseId);
        public Task<IEnumerable<TPurchase>> GetPurchaseByIds<TPurchase>(IReadOnlyList<Guid> keys, CancellationToken cancellation=default) where TPurchase : class, IPurchase;
    }
}
