using Domain.Entities;
using Domain.Interfaces.RepositoryBase;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.RepositoryService
{
    public class AccountRepostitory : AbstractRepository<AccountEntity, ApplicationDBContext>,IAccountRepository<AccountEntity>
    {
        public AccountRepostitory(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<bool> CheckEmail(string email)
        {
           return await base.dBContext.Set<AccountEntity>().AnyAsync(x => x.Email == email);
        }

        public async Task<AccountEntity?> FindAccountByEmailAsync(string email,CancellationToken cancellationToken=default )
        {
            return await base.dBContext.Set<AccountEntity>().FirstOrDefaultAsync(x=>x.Email==email,cancellationToken);
        }

        public async Task<AccountEntity?> FindAccountAndRoleAsync(Expression<Func<AccountEntity,bool>> expression,CancellationToken cancellationToken=default)
        {
            return await base.dBContext.Set<AccountEntity>().Where(expression)
                .Include(x => x.roleEntity)
                .ThenInclude(x => x.permissionEntities)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
