using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<AccountEntity?> FindAccountByEmailAsync(string email)
        {
            return await base.dBContext.Set<AccountEntity>().FirstOrDefaultAsync(x=>x.Email==email);
        }
    }
}
