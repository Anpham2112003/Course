using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public abstract class AbstractRepository<TEntity, TDBContext> : IRepository<TEntity> where TEntity : class, IEntity where TDBContext : DbContext
    {
        protected readonly TDBContext dBContext;

        protected readonly IMapper _mapper;
        protected AbstractRepository(TDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            _mapper = mapper;
        }



        public void AddOne(TEntity entity)
        {
            dBContext.Set<TEntity>().Add(entity);
        }

        public async Task AddOneAsync(TEntity entity)
        {
            await dBContext.Set<TEntity>().AddAsync(entity);
        }
        public async Task AddOneAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await dBContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public void AddMany(ICollection<TEntity> entities)
        {
            dBContext.Set<TEntity>().AddRange(entities);
        }


        public async Task AddManyAsync(ICollection<TEntity> entities)
        {
            await dBContext.Set<IEntity>().AddRangeAsync(entities);
        }


        public async Task AddManyAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
        {
            await dBContext.Set<IEntity>().AddRangeAsync(entities, cancellationToken);
        }




        public TEntity? FindOne<Id>(Id id)
        {
            return dBContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default)
        {
            return await dBContext.Set<TEntity>().FirstOrDefaultAsync(expression, cancellation);
        }

        public async Task<TEntity?> FindOneAsync<Id>(Id id)
        {
            return await dBContext.Set<TEntity>().FindAsync(id);
        }



        public async Task<TEntity?> FindAsync(object[] keys)
        {
            return await dBContext.Set<TEntity>().FindAsync(keys);
        }



        public void UpdateOne(TEntity entity)
        {
            dBContext.Set<TEntity>().Update(entity);
        }

        public void UpdateMany(ICollection<TEntity> entities)
        {
            dBContext.Set<TEntity>().UpdateRange(entities);
        }


        public void DeleteOne(TEntity entity)
        {
            dBContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteMany(ICollection<TEntity> entities)
        {
            dBContext.Set<TEntity>().RemoveRange(entities);
        }

        
    }
}
