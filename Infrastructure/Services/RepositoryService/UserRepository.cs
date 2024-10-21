using Domain.Entities;
using Domain.Interfaces.RepositoryBase;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.RepositoryService
{
    public class UserRepository : AbstractRepository<UserEntity, ApplicationDBContext>, IUserRepository<UserEntity>
    {
        public UserRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<UserEntity?> FindUserByAccountIdAsync(Guid accountId, CancellationToken cancellation = default)
        {
            return await dBContext.Set<UserEntity>().FirstOrDefaultAsync(x => x.AccountId == accountId);
        }
    }
}
