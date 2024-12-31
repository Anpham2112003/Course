using Domain.Entities;
using Domain.Interfaces.EntityBase;

namespace Infrastructure.Repository.RepositoryBase;

public interface IPermissionRepository<TEntity>:IRepository<TEntity> where TEntity:class,IEntity
{
    public  Task<IEnumerable<PermissionEntity>> GetPermissionsAsync(int skip, int limit, CancellationToken cancellation = default);
    public  Task<bool> CheckDuplicateRoute(string route, CancellationToken cancellation = default);
    public  Task<bool> CheckExist(int permissionId, CancellationToken cancellation = default);
    public  Task AddRolePermission(RolePermission permission, CancellationToken cancellation = default);
    public  Task<RolePermission?> GetRolePermission(int roleId, int permissionId, CancellationToken cancellation = default);
    public void RemoveRolePermission(RolePermission rolePermission);
}