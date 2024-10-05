using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
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

        public bool CheckEmail(string email)
        {
           return base.dBContext.Set<AccountEntity>().Any(x => x.Email == email);
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
