using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
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

        

    }
}
