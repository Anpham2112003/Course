﻿using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface IPaymentRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TPayment> GetPaymentByUserId<TPayment>(Guid userId);
    }
}
