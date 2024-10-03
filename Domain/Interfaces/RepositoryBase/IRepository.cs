using ApplicationCore.Interfaces.EntityBase;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryBase
{
    public interface IRepository<TEntity> where TEntity : class,IEntity
    {
        /// <summary>
        /// Add one Entity to Database
        /// </summary>
        /// <param name="entity"></param>
        public void AddOne(TEntity entity);



        /// <summary>
        /// Add one Entity to Database
        /// </summary>
        /// <param name="entity"></param>
        public Task AddOneAsync(TEntity entity);


        /// <summary>
        /// Add one Entity to Database
        /// </summary>
        /// <param name="entity"></param>
        public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken);




        /// <summary>
        /// Add many Entity to Database
        /// </summary>
        /// <param name="entities"></param>
        public void AddMany(ICollection<TEntity> entities);


        /// <summary>
        /// Add many Entity to Database Async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>

        public Task AddManyAsync(ICollection<TEntity> entities);

        /// <summary>
        /// Add many Entity to Database Async
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public Task AddManyAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        /// <typeparam name="Id">id type Guid ,int ,string</typeparam>
        /// <param name="id">Id type Guid, int ,string</param>
        /// <returns> Entity if exists or null</returns>
        public TEntity? FindOne<Id>(Id id);

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        /// <typeparam name="Id">id type Guid ,int ,string</typeparam>
        /// <param name="id">Id type Guid, int ,string</param>
        /// <returns> Entity if exists or null</returns>
        /// 

        public Task<TEntity?> FindOneAsync<Id>(Id id);


        /// <summary>
        /// 
        /// </summary>
        /// <returns>IQuryable</returns>
        public IQueryable<TEntity> EntityQueryable();



        /// <summary>
        /// Find by id
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public  Task<TEntity?> FindAsync(object[] keys);

        /// <summary>
        /// Update one record in DataBase
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateOne(TEntity entity);


        /// <summary>
        /// Update many record in Database
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateMany(ICollection<TEntity> entities);

        /// <summary>
        /// Delete one record in Database
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteOne(TEntity entity);

        /// <summary>
        /// Delete many record in Database
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteMany(ICollection<TEntity> entities);
    }
}
