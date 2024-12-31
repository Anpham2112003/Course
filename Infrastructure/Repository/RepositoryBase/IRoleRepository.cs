using Domain.Entities;
using Domain.Interfaces.EntityBase;

namespace Infrastructure.Repository.RepositoryBase;

public interface IRoleRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    public Task<RoleEntity?> GetRoleAndPermissionByIdAsync(int roleId);
    public Task<IEnumerable<PermissionEntity>> GetPermissionByRoleName(string roleName);
    public Task<bool> CheckDuplicateRole(string role, CancellationToken cancellationToken = default);
   
}