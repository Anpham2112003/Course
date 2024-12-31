using AutoMapper;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PermissionRepository:AbstractRepository<PermissionEntity,ApplicationDBContext>,IPermissionRepository<PermissionEntity>
{
    public PermissionRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
    {
    }

    public async Task<IEnumerable<PermissionEntity>> GetPermissionsAsync(int skip,int limit,CancellationToken cancellation = default)
    {
        return await this.dBContext.Set<PermissionEntity>()
            .Skip(skip).Take(limit)
            .ToListAsync(cancellation);
    }

    public async Task<bool> CheckDuplicateRoute(string route,CancellationToken cancellation=default)
    {
        return await this.dBContext.Set<PermissionEntity>()
            .Where(x=>x.Route!.Equals(route))
            .AnyAsync(cancellation);
    }

    public async Task<bool> CheckExist(int permissionId, CancellationToken cancellation = default)
    {
        return await this.dBContext.Set<PermissionEntity>()
            .Where(x=>x.Id == permissionId)
            .AnyAsync(cancellation);
    }

    public async Task AddRolePermission(RolePermission permission, CancellationToken cancellation = default)
    {
        await this.dBContext.Set<RolePermission>()
             .AddAsync(permission, cancellation);
    }

    public async Task<RolePermission?> GetRolePermission(int roleId, int permissionId, CancellationToken cancellation = default)
    {
        return await this.dBContext.Set<RolePermission>()
            .Where(x => x.RoleId == roleId && x.PermissionId == permissionId)
            .FirstOrDefaultAsync(cancellation);
    }

    public void RemoveRolePermission(RolePermission rolePermission)
    {
        this.dBContext.Set<RolePermission>().Remove(rolePermission);
    }
}