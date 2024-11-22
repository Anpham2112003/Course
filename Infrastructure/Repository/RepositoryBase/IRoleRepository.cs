using Domain.Entities;
using Domain.Interfaces.EntityBase;

namespace Infrastructure.Repository.RepositoryBase;

public interface IRoleRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    public Task<RoleEntity?> GetRoleAndPermissionByIdAsync(int roleId);
}