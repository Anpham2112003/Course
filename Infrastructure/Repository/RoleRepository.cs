using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoleRepository : AbstractRepository<RoleEntity, ApplicationDBContext>, IRoleRepository<RoleEntity>
{
    public RoleRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
    {
    }

    public async Task<RoleEntity?> GetRoleAndPermissionByIdAsync(int roleId)
    {
        return await dBContext.Set<RoleEntity>().Where(x => x.Id == roleId)
            .Include(x => x.permissionEntities)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PermissionEntity>> GetPermissionByRoleName(string roleName)
    {
        return await dBContext.Set<RoleEntity>().Where(x => x.RoleName==roleName)
            .Include(x => x.permissionEntities)
            .SelectMany(x=>x.permissionEntities)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> CheckDuplicateRole(string role,CancellationToken cancellationToken = default)
    {
        return await this.dBContext.Set<RoleEntity>()
            .Where(x => x.RoleName!.Equals(role))
            .AnyAsync(cancellationToken);
    }

    
}