using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountRepository : AbstractRepository<AccountEntity, ApplicationDBContext>, IAccountRepository<AccountEntity>
    {
        public AccountRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await dBContext.Set<AccountEntity>().AnyAsync(x => x.Email == email);
        }

        public async Task<AccountEntity?> FindAccountByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await dBContext.Set<AccountEntity>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<AccountEntity?> FindAccountAndRoleAsync(Expression<Func<AccountEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await dBContext.Set<AccountEntity>().Where(expression)
                .Include(x => x.userEntity)
                .Include(x => x.roleEntity)
                .ThenInclude(x => x!.permissionEntities)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
