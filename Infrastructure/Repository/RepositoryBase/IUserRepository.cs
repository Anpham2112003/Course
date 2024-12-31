using Domain.Interfaces.EntityBase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Schemas;
using Domain.DTOs;


namespace Infrastructure.Repository.RepositoryBase
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<TEntity?> FindUserByAccountIdAsync(Guid accountId, CancellationToken cancellation = default);

        public Task<IEnumerable<TUser>> GetUserByIds<TUser>(IReadOnlyList<Guid> keys, CancellationToken cancellation = default) where TUser : class, IUser;
        public Task<TUser?> GetUserById<TUser>(Guid id, CancellationToken cancellation = default) where TUser : class, IUser;

    }
}
