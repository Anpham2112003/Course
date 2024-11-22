using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoleRepository : AbstractRepository<RoleEntity, ApplicationDBContext>, IRoleRepository<RoleEntity>
{
    public RoleRepository(ApplicationDBContext dBContext) : base(dBContext)
    {
    }

    public async Task<RoleEntity?> GetRoleAndPermissionByIdAsync(int roleId)
    {
        return await dBContext.Set<RoleEntity>().Where(x => x.Id == roleId)
            .Include(x => x.permissionEntities)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}